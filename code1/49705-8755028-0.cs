        public static bool HasJpegHeader(string filename)
        {
            try
            {
                // 0000000: ffd8 ffe0 0010 4a46 4946 0001 0101 0048  ......JFIF.....H
                // 0000000: ffd8 ffe1 14f8 4578 6966 0000 4d4d 002a  ......Exif..MM.*    
                using (BinaryReader br = new BinaryReader(File.Open(filename, FileMode.Open, FileAccess.ReadWrite)))
                {
                    UInt16 soi = br.ReadUInt16();  // Start of Image (SOI) marker (FFD8)
                    UInt16 marker = br.ReadUInt16(); // JFIF marker (FFE0) EXIF marker (FFE1)
                    UInt16 markerSize = br.ReadUInt16(); // size of marker data (incl. marker)
                    UInt32 four = br.ReadUInt32(); // JFIF 0x4649464a or Exif  0x66697845
                    Boolean isJpeg = soi == 0xd8ff && (marker & 0xe0ff) == 0xe0ff;
                    Boolean isExif = isJpeg && four == 0x66697845;
                    Boolean isJfif = isJpeg && four == 0x4649464a;
                    
                    if (isJpeg) 
                    {
                        if (isExif)
                            Console.WriteLine("EXIF: {0}", filename);
                        else if (isJfif)
                            Console.WriteLine("JFIF: {0}", filename);
                        else
                            Console.WriteLine("JPEG: {0}", filename);
                    }
                    return isJpeg;
                    return isJfif;
                    return isExif;
                }
            }
            catch
            {
                return false;
            }
        }
