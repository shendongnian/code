            int width = 1000;
            int height = 10000;
            List<int[]> list = new List<int[]>();
            for (int i = 0; i < height; i++)
            {
                list.Add(Enumerable.Range(0, width).ToArray());
            }
            int[][] bazillionInts = list.ToArray();
            using (FileStream fsZ = new FileStream("c:\\temp_zipped.txt", FileMode.Create))
            using (FileStream fs = new FileStream("c:\\temp_notZipped.txt", FileMode.Create))
            using (GZipStream gz = new GZipStream(fsZ, CompressionMode.Compress))
            {
                BinaryFormatter f = new BinaryFormatter();
                f.Serialize(gz, bazillionInts);
                f.Serialize(fs, bazillionInts);
            }
