    public ActionResult DownloadHighChartHtml()
    {
        string serverPath = Server.MapPath("~/phantomjs/");
        string filename = DateTime.Now.ToString("ddMMyyyy_hhmmss") + ".pdf";
        string Url = "http://wwwabc.com";
        new Thread(new ParameterizedThreadStart(x =>
        {
            ExecuteCommand(string.Format("cd {0} & E: & phantomjs rasterize.js {1} {2} \"A4\"", serverPath, Url, filename));
                               //E: is the drive for server.mappath
        })).Start();
        var filePath = Path.Combine(Server.MapPath("~/phantomjs/"), filename);
        var stream = new MemoryStream();
        byte[] bytes = DoWhile(filePath);
        Response.ContentType = "application/pdf";
        Response.AddHeader("content-disposition", "attachment;filename=Image.pdf");
        Response.OutputStream.Write(bytes, 0, bytes.Length);
        Response.End();
        return RedirectToAction("HighChart");
    }
    private void ExecuteCommand(string Command)
    {
        try
        {
            ProcessStartInfo ProcessInfo;
            Process Process;
            ProcessInfo = new ProcessStartInfo("cmd.exe", "/K " + Command);
            ProcessInfo.CreateNoWindow = true;
            ProcessInfo.UseShellExecute = false;
            Process = Process.Start(ProcessInfo);
        }
        catch { }
    }
    private byte[] DoWhile(string filePath)
    {
        byte[] bytes = new byte[0];
        bool fail = true;
        while (fail)
        {
            try
            {
                using (FileStream file = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    bytes = new byte[file.Length];
                    file.Read(bytes, 0, (int)file.Length);
                }
                fail = false;
            }
            catch
            {
                Thread.Sleep(1000);
            }
        }
        System.IO.File.Delete(filePath);
        return bytes;
    }
