     static void Main(string[] args) {
    
                System.Random random = new Random();
    
                long[] arrayOriginal = new long[160000];
                long[] arrayRead = null;
    
                for (int i =0 ; i < arrayOriginal.Length; i++) {
                    arrayOriginal[i] = random.Next(int.MaxValue) * random.Next(int.MaxValue);
                }
    
                byte[] bytesOriginal = new byte[arrayOriginal.Length * sizeof(long)];
                System.Buffer.BlockCopy(arrayOriginal, 0, bytesOriginal, 0, bytesOriginal.Length);
    
                using (System.IO.MemoryStream stream = new System.IO.MemoryStream()) {
    
                    // write 
                    stream.Write(bytesOriginal, 0, bytesOriginal.Length);
    
                    // reset
                    stream.Flush();
                    stream.Position = 0;
    
                    int expectedLength = 0;
                    checked {
                        expectedLength = (int)stream.Length;
                    }
                    // read
                    byte[] bytesRead = new byte[expectedLength];
    
                    if (expectedLength == stream.Read(bytesRead, 0, expectedLength)) {
                        arrayRead = new long[expectedLength / sizeof(long)];
                        Buffer.BlockCopy(bytesRead, 0, arrayRead, 0, expectedLength);
                    }
                    else {
                        // exception
                    }
    
                    // check 
                    for (int i = 0; i < arrayOriginal.Length; i++) {
                        if (arrayOriginal[i] != arrayRead[i]) {
                            throw new System.Exception();
                        }
                    }
                }
    
                System.Console.WriteLine("Done");
                System.Console.ReadKey();
            }
