    using (ZipFile zip = ZipFile.Read(zipfile) )
    {
        bool header = true;
        foreach (ZipEntry e in zip)
        {
            if (header)
            {
                System.Console.WriteLine("Zipfile: {0}", zip.Name);
                if ((zip.Comment != null) && (zip.Comment != ""))
                    System.Console.WriteLine("Comment: {0}", zip.Comment);
                System.Console.WriteLine("\n{1,-22} {2,9}  {3,5}   {4,9}  {5,3} {6,8} {0}",
                                         "Filename", "Modified", "Size", "Ratio", "Packed", "pw?", "CRC");
                System.Console.WriteLine(new System.String('-', 80));
                header = false;
            }
            System.Console.WriteLine("{1,-22} {2,9} {3,5:F0}%   {4,9}  {5,3} {6:X8} {0}",
                                     e.FileName,
                                     e.LastModified.ToString("yyyy-MM-dd HH:mm:ss"),
                                     e.UncompressedSize,
                                     e.CompressionRatio,
                                     e.CompressedSize,
                                     (e.UsesEncryption) ? "Y" : "N",
                                     e.Crc32);
            if ((e.Comment != null) && (e.Comment != ""))
                System.Console.WriteLine("  Comment: {0}", e.Comment);
        }
    }
