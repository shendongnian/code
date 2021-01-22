     public void DTToExcel(DataTable dt)
    {
        // dosya isimleri ileride aynı anda birden fazla kullanıcı aynı dosya üzerinde işlem yapmak ister düşüncesiyle guid yapıldı. 
        string FileName = Guid.NewGuid().ToString();
        FileInfo f = new FileInfo(Server.MapPath("Downloads") + string.Format("\\{0}.xlsx", FileName));
        if (f.Exists)
            f.Delete(); // delete the file if it already exist.
        HttpResponse response = HttpContext.Current.Response;
        response.Clear();
        response.ClearHeaders();
        response.ClearContent();
        response.Charset = Encoding.UTF8.WebName;
        response.AddHeader("content-disposition", "attachment; filename=" + FileName + ".xls");
        response.AddHeader("Content-Type", "application/Excel");
        response.ContentType = "application/vnd.xlsx";
        //response.AddHeader("Content-Length", file.Length.ToString());
        // create a string writer
        using (StringWriter sw = new StringWriter())
        {
            using (HtmlTextWriter htw = new HtmlTextWriter(sw)) //datatable'a aldığımız sorguyu bir datagrid'e atayıp html'e çevir.
            {
                // instantiate a datagrid
                DataGrid dg = new DataGrid();
                dg.DataSource = dt;
                dg.DataBind();
                dg.RenderControl(htw);
                response.Write(sw.ToString());
                dg.Dispose();
                dt.Dispose();
                response.End();
            }
        }
    }
