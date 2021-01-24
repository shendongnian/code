    public Stream Download()
        {
            string file = @"C:\1.png";
            try
            {
                //MemoryStream ms = new MemoryStream();
                //Stream stream = File.OpenRead(file);
                FileStream fs = new FileStream(file, FileMode.OpenOrCreate, FileAccess.Read, FileShare.None);
                //byte[] bytes = new byte[fs.Length];
                //fs.Read(bytes, 0, (int)fs.Length);
                //ms.Write(bytes, 0, (int)fs.Length);
                WebOperationContext.Current.OutgoingResponse.ContentType = "image/png";
                WebOperationContext.Current.OutgoingResponse.Headers.Add("Content-disposition", "inline; filename=Scan.Tiff");
                return fs;
                //return Stream;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
