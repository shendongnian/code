        var directory = new DirectoryInfo(ConfigurationManager.AppSettings["ReportDirectory"]);
        // the latest excel file
        var file = directory.GetFiles().OrderByDescending(c => c.LastWriteTime).FirstOrDefault();
        if (file == null)
        {
            return;
        }
        
        var content = File.ReadAllBytes(file.FullName);
        HttpContext.Current.Response.ContentType = "text/csv";
        HttpContext.Current.Response.AddHeader("content-disposition", "attachment; filename=" + file.Name + ".xlsx");
        HttpContext.Current.Response.BufferOutput = true;
        HttpContext.Current.Response.OutputStream.Write(content, 0, content.Length);
        HttpContext.Current.Response.End();
