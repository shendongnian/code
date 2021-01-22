        DateTime current = DateTime.Now;
        string file = @"C:\text.iso";//It's 2.5 Gb file
        string output;
        using (var md5 = MD5.Create())
        {
            using (var stream = File.OpenRead(file))
            {
                byte[] checksum = md5.ComputeHash(stream);
                output = BitConverter.ToString(checksum).Replace("-", String.Empty).ToLower();
                Console.WriteLine("Total seconds : " + (DateTime.Now - current).TotalSeconds.ToString() + " " + output);
            }
        }
