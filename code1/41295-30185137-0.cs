    DataTable dt = new DataTable("GridView_Data");
    // Fill your DataTable here...
    
    //Export:
        using (XLWorkbook wb = new XLWorkbook())
        {
            wb.Worksheets.Add(dt);
     
            Response.Clear();
            Response.Buffer = true;
            Response.Charset = "";
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-disposition", "attachment;filename=GridView.xlsx");
            using (MemoryStream MyMemoryStream = new MemoryStream())
            {
                wb.SaveAs(MyMemoryStream);
                MyMemoryStream.WriteTo(Response.OutputStream);
                Response.Flush();
                Response.End();
            }
        }
