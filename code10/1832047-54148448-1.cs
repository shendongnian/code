            Dictionary<int, byte[]> byteDictionary = new Dictionary<int, byte[]>();
            using (FileStream fsInput =new FileStream(inputfilename, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (FileStream fsOutput = File.Create(outputfilename))
                {
                    long total = fsInput.Length;
                    long progress = 0;
                    unsafe
                    {
                        int hdrSize = sizeof(FullMessageHeader);
                        byte[] headerBuffer = new byte[hdrSize];
                        while (fsInput.Position < fsInput.Length)
                        {                         
                            progress += fsInput.Read(headerBuffer, 0, hdrSize);
                            int msgSize = 0;
                            fixed (byte* hdr = headerBuffer)
                            {
                                msgSize = *(int*)(hdr + MessageHeaderOffsets.Size);
                            }
                            byte[] msg = byteDictionary.ContainsKey(msgSize)
                                ? byteDictionary[msgSize]
                                : new byte[msgSize];
                            if (!byteDictionary.ContainsKey(msgSize))
                            {
                                byteDictionary[msgSize] = msg;
                            }
                            //byte[] msg = new byte[msgSize];
                            //Buffer.BlockCopy(headerBuffer, 0, msg, 0, headerBuffer.Length);
                            fsInput.Position -= hdrSize;
                            progress += fsInput.Read(msg, 0, msgSize);
                            fixed (byte* ptr = msg)
                            {
                                //fsOutput.Write(msg,0,msg.Length);
                                byte[] ba = ProcessMessage(ptr);
                                if (ba.Length == 0)
                                {
                                    fsOutput.Write(msg, 0, msg.Length);
                                }
                                else
                                {
                                    fsOutput.Write(ba, 0, ba.Length);
                                }
                            }
                        }
                    }
                }
            }
