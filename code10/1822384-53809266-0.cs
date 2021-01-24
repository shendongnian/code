    public void DownloadFile()
    {
        MemoryStream ms = new MemoryStream();
        using (MemoryStream stream = new MemoryStream())
        {
            Response.Headers.Add("Content-disposition", "attachment; filename=\"MyExce.xlsx\"");
            Response.Headers.Add("Content-type", "octet-stream");
            SXSSFWorkbook wb = new SXSSFWorkbook();
            SXSSFSheet sheet = (SXSSFSheet)wb.CreateSheet("FirstSheet");
            IRow row = sheet.CreateRow(0);
            ICell cell = row.CreateCell(0);
            cell.SetCellValue("firstCell");
            //Write file to output stream
            wb.Write(stream);
            var byteArray = stream.ToArray();
            ms.Write(byteArray, 0, byteArray.Length);
            ms.Seek(0, SeekOrigin.Begin);
            ms.WriteTo(Response.Body);
        }
    }
