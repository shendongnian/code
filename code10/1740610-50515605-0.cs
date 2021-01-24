    public ActionResult DownloadReport(string fileName)
    {
        FileResult result = null;
        FileStreamResult st = null;
        if (StaticData.ReportsTemp.ContainsKey(fileName))
        {
            st = StaticData.ReportsTemp[fileName] as FileStreamResult;
            result = st;
            StaticData.ReportsTemp.Remove(fileName);
            
            if (st.ContentType == MediaTypeNames.Application.Pdf)
            {
                var cd = new ContentDisposition { FileName = fileName, Inline = true };
                Response.AppendHeader("Content-Disposition", cd.ToString());
    
                System.IO.BinaryReader br = new System.IO.BinaryReader(st.FileStream);
                var buff = br.ReadBytes((int)st.FileStream.Length);
                return File(buff, st.ContentType);
            }
        }
        return View("PageNotFound");
    }
