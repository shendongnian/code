            Stopwatch sw = new Stopwatch();
            Random rand = new Random();  // seed a random number generator
            int numberOfBytes = 2 << 22; //8,192KB File
            byte nextByte;
            for (int i = 1; i <= 28; i++) //Limited loop to 28 to prevent out of memory
            {
                sw.Start();
                using (FileStream fs = new FileStream(
                    String.Format(@"C:\TEMP\TEST{0}.DAT", i),  // name of file
                    FileMode.Create,    // create or overwrite existing file
                    FileAccess.Write,   // write-only access
                    FileShare.None,     // no sharing
                    2 << i,             // block transfer of i=18 -> size = 256 KB
                    FileOptions.None))  
                {
                    for (int j = 0; j < numberOfBytes; j++)
                    {
                        nextByte = (byte)(rand.Next() % 256); // generate a random byte
                        fs.WriteByte(nextByte);               // write it
                    } 
                }
                sw.Stop();
                Console.WriteLine(String.Format("Buffer is 2 << {0} Elapsed: {1}", i, sw.Elapsed));
                sw.Reset();
            }
