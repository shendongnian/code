    public void DoDownload(Range[] Ranges)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(m_Source);
            request.Credentials = CredentialCache.DefaultCredentials;
            foreach (Range r in Ranges)
            {
                request.AddRange(r.From, r.To);
            }
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string boundary = "";
            Match m = Regex.Match(response.ContentType, @"^.*boundary=(?<boundary>.*)$");
            if (m.Success)
            {
                boundary = m.Groups["boundary"].Value;
            }
            else
            {
                throw new InvalidDataException("invalid packet data: no boundary specification found.");
            }
            using (Stream source = response.GetResponseStream())
            {
                using (FileStream target = File.Open(m_TargetFile, FileMode.OpenOrCreate, FileAccess.Write, FileShare.ReadWrite))
                {
                    // buffer for payload
                    byte[] buffer = new byte[4096];
                    // buffer for current range header
                    byte[] header = new byte[200];
                    // next header after x bytes
                    int NextHeader = 0;
                    // current position in header[]
                    int HeaderPosition = 0;
                    // current position in buffer[]
                    int BufferPosition = 0;
                    // left data to proceed
                    int BytesToProceed = 0;
                    // total data written without range-headers
                    long TotalBytesWritten = 0;
                    // count of last data written to target file
                    int BytesWritten = 0;
                    // size of processed header data
                    int HeaderSize = 0;
                    // count of last data read from ResponseStream
                    int BytesRead = 0;
                    while ((BytesRead = source.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        BufferPosition = 0;
                        BytesToProceed = BytesRead;
                        HeaderSize = 0;
                        while (BytesToProceed > 0)
                        {
                            if (NextHeader == 0)
                            {
                                for (;HeaderPosition < header.Length; HeaderPosition++, BufferPosition++, HeaderSize++)
                                {
                                    if (BytesToProceed > HeaderPosition && BufferPosition < BytesRead)
                                    {
                                        header[HeaderPosition] = buffer[BufferPosition];
                                        if (HeaderPosition >= 4 &&
                                            header[HeaderPosition - 3] == 0x0d &&
                                            header[HeaderPosition - 2] == 0x0a &&
                                            header[HeaderPosition - 1] == 0x0d &&
                                            header[HeaderPosition] == 0x0a)
                                        {
                                            string RangeHeader = Encoding.ASCII.GetString(header, 0, HeaderPosition + 1);
                                            Match mm = Regex.Match(RangeHeader,
                                                @"^\r\n(--)?" + boundary + @".*?(?<from>\d+)\s*-\s*(?<to>\d+)/.*\r\n\r\n", RegexOptions.Singleline);
                                            if (mm.Success)
                                            {
                                                int RangeStart = Convert.ToInt32(mm.Groups["from"].Value);
                                                int RangeEnd = Convert.ToInt32(mm.Groups["to"].Value);
                                                NextHeader = (RangeEnd - RangeStart) + 1; 
                                                target.Seek(RangeStart, SeekOrigin.Begin);
                                                BufferPosition++;
                                                BytesToProceed -= HeaderSize + 1;
                                                HeaderPosition = 0;
                                                HeaderSize = 0;
                                                break;
                                            }
                                            else { throw new InvalidDataException("invalid header: missing range specification.");}
                                        }
                                    }
                                    else { goto READ_NEW; }
                                }
                                if (NextHeader == 0)
                                    throw new InvalidDataException("invalid packet data: no range-header found.");
                            }
                            BytesWritten = (NextHeader > BytesToProceed) ? BytesToProceed : NextHeader;
                            target.Write(buffer, BufferPosition, BytesWritten);
                            BytesToProceed -= BytesWritten;
                            NextHeader -= BytesWritten;
                            BufferPosition += BytesWritten;
                            TotalBytesWritten += BytesWritten;
                        }
                    READ_NEW:;
                    }
                }
            }
        }
