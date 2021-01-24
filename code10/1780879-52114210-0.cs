                byte[,] image = { 
                                      {0x00, 0x01, 0x02, 0x03},
                                      {0x04, 0x05, 0x06, 0x07},
                                      {0x08, 0x09, 0x0A, 0x0B},
                                      {0x0C, 0x0D, 0x0E, 0x0F}
                                  };
                int length = image.GetLength(0);
                int width = image.GetLength(1);
                List<List<List<byte>>> bytes = new List<List<List<byte>>>();
                for (int row = 0; row < length; row += 2)
                {
                    for (int col = 0; col < width; col += 2)
                    {
                        bytes.Add(new List<List<byte>>()  { 
                             new List<byte>() { image[row, col], image[row, col + 1]} , 
                             new List<byte>() { image[row + 1, col], image[row + 1, col + 1] } 
                        });
                    }
                }
