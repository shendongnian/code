    using (var fs = File.OpenRead("somefile.eng"))
    using (var br = new BinaryReader(fs))
    using (var csv = new StreamWriter("output.csv", false, Encoding.ASCII))
    {
        // Note that the array is useless, because we write the csv
        // one int at a time!
        int[] row = new int[16];
        while (true)
        {
            // Note that the file must be composed of only
            // blocks of 16 int32 . No dangling byte
            for (int i = 0; i < 16; i++)
            {
                if (i != 0)
                {
                    csv.Write(';');
                }
                row[i] = br.ReadInt32();
                csv.Write(row[i]);
            }
            // End of file
            if (br.PeekChar() == -1)
            {
                break;
            }
            csv.WriteLine();
        }
    }
