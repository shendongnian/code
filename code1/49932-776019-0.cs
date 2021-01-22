            string filePath = Server.MapPath("~/" + document.Path + "/" + document.Filename);
            System.IO.FileInfo targetFile = new System.IO.FileInfo(filePath);
            if(targetFile.Exists)
            {
                Response.Clear();
                Response.AddHeader("Content-Disposition", "attachment; filename=" + targetFile.Name);
                Response.AddHeader("Content-Length", targetFile.Length.ToString());
                Response.ContentType = "application/octet-stream";
                Response.WriteFile(targetFile.FullName);
            }
