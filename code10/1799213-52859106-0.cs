    private void GetParseMime()
    {
        byte[] beginPattern = new byte[0];
        byte[] endPattern = new byte[0];
        WebClient webClient = new WebClient();
        webClient.Headers["Accept"] = textBoxMimeType.Text;
        bool bBeginSeqFound = false;
        long savedBytesRead = 0;
        var uri = new Uri(url);
        using (Stream webStream = webClient.OpenRead(uri))
        {
            long finalContentLen = long.Parse(webClient.ResponseHeaders["Content-Length"]);
            using (FileStream fileStream = new FileStream(outputFilename, FileMode.Create))
            {
                var buffer = new byte[32768];
                int bytesRead;
                long bytesTotal = Convert.ToInt64(webClient.ResponseHeaders["Content-Length"]);
                while ((bytesRead = webStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    int len = bytesRead;
                    //look for the start sequence
                    if (!bBeginSeqFound)
                    {
                        int i = IndexOfSequence(buffer, dcmBeginPattern, 0);
                        if (i > -1)
                        {
                            bBeginSeqFound = true;
                            buffer = buffer.Skip(i).Take(bytesRead - i).ToArray();
                            len = bytesRead - i;
                        }
                    }
                    else
                    {
                        //look for end sequence
                        int i = IndexOfSequence(buffer, dcmEndPattern, 0);
                        if (i > -1)
                        {
                            buffer = buffer.Skip(0).Take(i).ToArray();
                            len = buffer.Length;
                        }
                    }
                    savedBytesRead += len;
                    fileStream.Write(buffer, 0, len);
                }
            }
        }
    }
