    private bool CompareFilesByte(string file1, string file2)
    {
        using (var fs1 = new FileStream(file1, FileMode.Open))
        using (var fs2 = new FileStream(file2, FileMode.Open))
        {
            if (fs1.Length != fs2.Length) return false;
            int b1, b2;
            do
            {
                b1 = fs1.ReadByte();
                b2 = fs2.ReadByte();
                if (b1 != b2 || b1 < 0) return false;
            }
            while (b1 >= 0);
        }
        return true;
    }
    
    private string HashFile(string file)
    {
        using (var fs = new FileStream(file, FileMode.Open))
        using (var reader = new BinaryReader(fs))
        {
            var hash = new SHA512CryptoServiceProvider();
            hash.ComputeHash(reader.ReadBytes((int)file.Length));
            return Convert.ToBase64String(hash.Hash);
        }
    }
    
    private bool CompareFilesWithHash(string file1, string file2)
    {
        var str1 = HashFile(file1);
        var str2 = HashFile(file2);
        return str1 == str2;
    }
