    //HttpContext.Current.Response.Clear();
    //HttpContext.Current.Response.Buffer = true;
    //System.Web.HttpContext.Current.Response.Charset = "";
    //System.Web.HttpContext.Current.Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
    //System.Web.HttpContext.Current.Response.AddHeader("content-disposition", "attachment;filename= SubmissionForm.xlsx");
    using (MemoryStream MyMemoryStream = new MemoryStream())
    {
        wb.SaveAs(MyMemoryStream);
        //you need to replace below line according to your need. **
        //MyMemoryStream.WriteTo(System.Web.HttpContext.Current.Response.OutputStream);
        //System.Web.HttpContext.Current.Response.Flush();
        //System.Web.HttpContext.Current.Response.End();
    }
