    //StreamReader reader = new StreamReader(stream);
    //Console.WriteLine(reader.ReadToEnd());
    string fileName = "fileName.csv";
    HttpContext.Current.Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
    HttpContext.Current.Response.AddHeader("content-disposition", string.Format("attachment;filename={0}", fileName));
    stream.Position = 0;
    stream.WriteTo(HttpContext.Current.Response.OutputStream);
