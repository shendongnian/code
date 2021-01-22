                    Response.Clear();
                    Response.ContentType = "application/octet-stream";
                    Response.AddHeader("Content-Disposition", "attachment; filename=" + downloadName);
                    while (dataToRead > 0)
                    {
                        if (Response.IsClientConnected)
                        {
                            fileLength = iStream.Read(buffer, 0, buffer.Length);
                            Response.OutputStream.Write(buffer, 0, fileLength);
                            Response.Flush();
                            dataToRead = dataToRead - fileLength;
                        }
                        else
                        {
                            dataToRead = -1;//prevent infinite loop if user disconnects
                        }
                    }
