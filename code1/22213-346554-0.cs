    System.IO.MemoryStream stream = new System.IO.MemoryStream();
    stream = (System.IO.MemoryStream)this.Report.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
    this.Response.Clear();
    this.Response.Buffer = true;
    this.Response.ContentType = "application/pdf";
    this.Response.AddHeader("Content-Disposition", "attachment; filename=\""+FILENAME+"\"");
    this.Response.BinaryWrite(stream.ToArray());
    this.Response.End();
