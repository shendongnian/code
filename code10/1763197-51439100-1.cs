    string input = "test.hex";
    string output = "output.bin";
    using (var sr = new StreamReader(input))
    using (var fs = File.Create(output))
    {
        // We accumulate the 2 hex digits needed for a byte here
        string h = string.Empty;
        while (true)
        {
            int ch1 = sr.Read();
            if (ch1 == -1)
            {
                // The file finished but we have a pending partial hex code
                if (h.Length == 1)
                {
                    throw new Exception("Malformed file");
                }
                break;
            }
            char ch2 = (char)ch1;
            // Skip white space and end-of-line
            if (char.IsWhiteSpace(ch2))
            {
                continue;
            }
            h += ch2;
            // We have collected 2 hex digits, so we have 1 byte
            if (h.Length == 2)
            {
                byte b = Convert.ToByte(h, 16);
                fs.WriteByte(b);
                h = string.Empty;
            }
        }
    }
