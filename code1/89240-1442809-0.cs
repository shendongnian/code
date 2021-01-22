                        fss.Position = (long)totalLength;
                        fss.Read(buffer, 0, bufferLength);
                        totalLength += bufferLength;
                        appLength += bufferLength;
                        fsa.Write(buffer, 0, bufferLength);
                        Remaining = RemaingDatalength - appLength;
                        if (Remaining < bufferLength)
                        {
                            byte[] buff = new byte[Remaining];
                            fss.Read(buff, 0, Remaining);
                            fsa.Write(buff, 0, Remaining);
                            break;
                        }
                    }
                    fss.Close();
                    fsa.Close();
                    MessageBox.Show("Filetransfer Completed");
