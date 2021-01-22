    using (MemoryStream ms2 = new MemoryStream())
            {
                int bytes = 0;            
                while (true)
                {
                   int byteLen = ms.Length - ms.Position >= 4096 ? 4096 : ms.Length -  ms.Position;
                   byte[] temp = new byte[byteLen];
                   bytes = ms.Read(temp, 0, byteLen);
                   ms2.Write(temp, 0, bytes);
                   imageFromUrl = new Bitmap(ms2);
                   if (ms.Position == ms.Length) break;
            }
