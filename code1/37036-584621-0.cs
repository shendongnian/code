    HttpResponse currentResponse = HttpContext.Current.Response;
    currentResponse.Clear();
    currentResponse.ClearHeaders();
    currentResponse.ClearContent();
    filename = String.Format("{0}.pdf", this.ReportName);
    currentResponse.AppendHeader("Content-Disposition", String.Format("inline;filename={0}", filename));
    currentResponse.ContentType = "Application/PDF";
    //Copy the content of the response to the current response
    List<byte> bytes = new List<byte>();
    
    using (Stream responseStream = ssrsResponse.GetResponseStream())
    {
    
    int byteInt = responseStream.ReadByte();
    while (byteInt >= 0)
    {
        bytes.Add((byte) byteInt);
        byteInt = responseStream.ReadByte();
    }
    }
    currentResponse.BinaryWrite(bytes.ToArray());
    currentResponse.End();
