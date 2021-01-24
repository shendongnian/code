                int _imageRowSize = 288;
                int _imageColSize = 384;
                int _count = 0;
                byte[] buffer = new byte[_imageColSize * _imageRowSize];
                Image<Gray, UInt16> image = new Image<Gray, UInt16>(_imageColSize,_imageRowSize);
                Console.WriteLine("Creating Client Pipe");
                NamedPipeClientStream pipe = new NamedPipeClientStream(".", "HyperPipe", PipeDirection.InOut);
                Console.WriteLine("Pipe Created Successfully, Connecting to Server");
                pipe.Connect();
                Console.WriteLine("Successfully, Connected to Server");
                using (MemoryStream ms = new MemoryStream())
                {
                    while (true)
                    {
                        _count = 0;      
                        int read = pipe.Read(buffer, 0, buffer.Length);
                        for (int _imageRow = 0; _imageRow < 288; _imageRow++)
                        {
                            for (int _imageCol = 0; _imageCol < 384; _imageCol++)
                            {
                                try
                                {
                                    image.Data[_imageRow, _imageCol, 0] = (UInt16)(buffer[_count] * 255);
                                }catch(Exception exception)
                                {
                                    Console.WriteLine(exception);
                                }
                                _count++;
                            }
                        }
                        if (read <= 0)
                            break;
                        ms.Write(buffer, 0, read);
                    }
                }           
                CvInvoke.Imshow("Image", image);
            }
 
