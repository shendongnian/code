    byte[] array = listOfInts.ConvertAll( new Converter<byte, int>(
                          delegate(int i) { 
                              if(i < 0)
                                 return (byte)0;
                              else if(i > 255)
                                 return (byte)255;
                              else
                                 return System.Convert.ToByte(i);
                           }) ).ToArray();
