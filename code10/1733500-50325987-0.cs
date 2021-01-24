    MemoryStream ms = new MemoryStream();
    xml.Save(ms);
    byte[] bytes = ms.ToArray();
    Response.Clear();
    Response.AddHeader("Content-Disposition", string.Format("attachment;filename={0}.xml", filename));
    Response.ContentType = "text/xml";
    Response.BinaryWrite(bytes);
    Response.Flush();
    Response.End();
