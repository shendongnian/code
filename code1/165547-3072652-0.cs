                do
                {
                    // !!! problematic function call here !!!
                    int BytesRead = NPSS.Read(PipeDataBuffer, 0, PipeDataBuffer.Length);
                    // !!!
                    MessageStream.Write(PipeDataBuffer, 0, BytesRead);
                    TotalBytesRead += BytesRead;
                } while (!NPSS.IsMessageComplete);
