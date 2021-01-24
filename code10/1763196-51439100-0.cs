    string input = "test.hex";
    string output = "output.bin";
    using (var sr = new StreamReader(input))
    using (var fs = File.Create(output))
    {
        while (true)
        {
            int ch1 = sr.Read();
            if (ch1 == -1)
            {
                break;
            }
            int ch2 = sr.Read();
            if (ch2 == -1)
            {
                throw new Exception("Malformed file");
            }
            string h = string.Empty + (char)ch1 + (char)ch2;
            byte b = Convert.ToByte(h, 16);
            fs.WriteByte(b);
        }
    }
