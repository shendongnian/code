            MemoryStream wtt=new MemoryStream();
            using (var gs=new GZipStream(wtt,CompressionMode.Compress,true))
            {
                using (var sw=new StreamWriter(gs,Encoding.ASCII,1024,true))
                {
                    sw.WriteLine("Hello");
                }
            }
            wtt.Position = 0;
            using (var ds = new DeflateStream(wtt, CompressionMode.Decompress, true))
            {
                using (var sr=new StreamReader(ds,Encoding.ASCII,true,1024,true))
                {
                    var txt = sr.ReadLine();
                }
            }
