     public static void Zip(HttpResponse Response, HttpServerUtility Server, string[] pathes)
        {
            Response.Clear();
            Response.BufferOutput = false;         
           
            string archiveName = String.Format("archive-{0}.zip",
                                              DateTime.Now.ToString("yyyy-MMM-dd-HHmmss"));
            Response.ContentType = "application/zip";
            Response.AddHeader("content-disposition", "filename=" + archiveName);
            var path = Server.MapPath(@"../TempFile/TempFile" + DateTime.Now.Ticks);
            if (!Directory.Exists(Server.MapPath(@"../TempFile")))
                Directory.CreateDirectory(Server.MapPath(@"../TempFile"));
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            var pathzipfile = Server.MapPath(@"../TempFile/zip_" + DateTime.Now.Ticks + ".zip");
            for (int i = 0; i < pathes.Length; i++)
            {
                string dst = Path.Combine(path, Path.GetFileName(pathes[i]));
                File.Copy(pathes[i], dst);
            }
            if (File.Exists(pathzipfile))
                File.Delete(pathzipfile);
            ZipFile.CreateFromDirectory(path, pathzipfile);
            {
                byte[] bytes = File.ReadAllBytes(pathzipfile);
                Response.OutputStream.Write(bytes, 0, bytes.Length);
            }
            Response.Close();
            File.Delete(pathzipfile);
            Directory.Delete(path, true);
        }  
