        String FileName1 = "test.mp3";
        String FilePath1 = "~/audio/test.mp3";
        String FileName = "FileName1";
        String FilePath = FilePath1;
        System.Web.HttpResponse response = System.Web.HttpContext.Current.Response;
        response.ClearContent();
        response.Clear();
        response.ContentType = "text/plain";
        response.AddHeader("Content-Disposition", "attachment; filename=" + FileName + ";");
        response.TransmitFile(FilePath);
        response.Flush();
        response.End();
    }
