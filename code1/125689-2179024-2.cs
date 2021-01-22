    public void StreamFile(string filePath)
    {
        string fileName = Path.GetFileName(filePath);
        using (var fStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
        {
            var contentLength = fStream.Length;
            if (Request.UserAgent.Contains("MSIE"))
            {
                Response.AddHeader("Content-Transfer-Encoding", "binary");
            }
            Response.ContentType = "application/octet-stream";
            Response.AddHeader("Content-Length", contentLength.ToString());
            // Even though "Content-Disposition" should have an upper-case "d", as per http://www.ietf.org/rfc/rfc2183.txt
            // IE fails to recognize this if the "d" is upper-cased.
            Response.AddHeader("Content-disposition", "attachment; filename=" + fileName);
            var buffer = new byte[8192];
            while (Response.IsClientConnected)
            {
                var count = fStream.Read(buffer, 0, buffer.Length);
                if (count == 0)
                {
                    break;
                }
                Response.OutputStream.Write(buffer, 0, count);
                Response.Flush();
            }
        }
        Response.Close();
    }
