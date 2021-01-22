            string fileName = @"C:\TEMP\TEST.DAT";
            //Use below to generate a file for testing
            //using (FileStream fs = new FileStream(fileName,FileMode.OpenOrCreate))
            //{
            //    Random rand = new Random();			// seed a random number generator
            //    int numberOfBytes = 2 << 28;
            //    for (int j = 0; j < numberOfBytes; j++)
            //    {			// write 100 random bytes
            //        byte nextByte = (byte)(rand.Next() % 256); // generate a random byte
            //        fs.WriteByte(nextByte);			// write it
            //    } 
            //}
            Stopwatch sw = new Stopwatch();
            for (int i = 1; i <= 28; i++) //Limited loop to 28 to prevent out of memory
            {
                sw.Start();
                using (StreamReader sr = new StreamReader(new FileStream(fileName,	// name of file
                                FileMode.Open,			// open existing file
                                FileAccess.Read,	// read-only access
                                FileShare.None,		// no sharing
                                2 << i,			// block transfer of i=18 -> size = 256 KB
                                FileOptions.SequentialScan)))	// sequential access
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                    }
                }
                sw.Stop();
                Console.WriteLine(String.Format("Buffer is 2 << {0} Elapsed: {1}",i,sw.Elapsed));
                sw.Reset();
            }
