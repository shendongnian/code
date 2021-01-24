        static void DownloadFilesFromSharePoint(string siteUrl, string siteFolderPath, string localTempLocation)
        {
            ClientContext ctx = new ClientContext(siteUrl);
            ctx.Credentials = new NetworkCredential("username", "password", "Domain");
            FileCollection files = ctx.Web.GetFolderByServerRelativeUrl(siteFolderPath).Files;
            ctx.Load(files);
            if (ctx.HasPendingRequest)
            {
                ctx.ExecuteQuery();
            }
            foreach (File file in files)
            {                
                    FileInformation fileInfo = File.OpenBinaryDirect(ctx, file.ServerRelativeUrl);
                    ctx.ExecuteQuery();
                    var filePath = localTempLocation + "\\" + file.Name;
                    System.IO.FileStream fileStream = new System.IO.FileStream(filePath, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.ReadWrite, System.IO.FileShare.ReadWrite);
                    fileInfo.Stream.CopyTo(fileStream);
                
            }
        } 
