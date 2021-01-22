    private bool IsValidImage(string filename)
    {
        Stream imageStream = null;
        try
        {
            imageStream = new FileStream(filename, FileMode.Open);
    
            if (imageStream.Length > 0)
            {
                byte[] header = new byte[30]; // Change size if needed.
                string[] imageHeaders = new[]
                {
                    "BM",       // BMP
                    "GIF",      // GIF
                    Encoding.ASCII.GetString(new byte[]{137, 80, 78, 71}),// PNG
                    "MM\x00\x2a", // TIFF
                    "II\x2a\x00" // TIFF
                };
    
                imageStream.Read(header, 0, header.Length);
    
                bool isImageHeader = imageHeaders.Count(str => Encoding.ASCII.GetString(header).StartsWith(str)) > 0;
                if (imageStream != null)
                {
                    imageStream.Close();
                    imageStream.Dispose();
                    imageStream = null;
                }
    
                if (isImageHeader == false)
                {
                    //Verify if is jpeg
                    using (BinaryReader br = new BinaryReader(File.Open(filename, FileMode.Open)))
                    {
                        UInt16 soi = br.ReadUInt16();  // Start of Image (SOI) marker (FFD8)
                        UInt16 jfif = br.ReadUInt16(); // JFIF marker
    
                        return soi == 0xd8ff && (jfif == 0xe0ff || jfif == 57855);
                    }
                }
    
                return isImageHeader;
            }
    
            return false;
        }
        catch { return false; }
        finally
        {
            if (imageStream != null)
            {
                imageStream.Close();
                imageStream.Dispose();
            }
        }
    }
