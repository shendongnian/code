            Response.Clear();
            Response.ContentType = @"application\octet-stream";
            System.IO.FileInfo file = new System.IO.FileInfo(ubicacion);
            Response.AddHeader("Content-Disposition", "attachment; filename=" + nombre);
            Response.AddHeader("Content-Length", file.Length.ToString());
            Response.ContentType = "application/octet-stream";
            Response.WriteFile(file.FullName);
            Response.Flush();
        }
