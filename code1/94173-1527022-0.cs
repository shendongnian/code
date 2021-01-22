try
{
    Response.Buffer = false;
    Response.AppendHeader("Content-Disposition", "attachment;filename=" + file.Name);
    Response.AppendHeader("Content-Type", "application/octet-stream");
    Response.AppendHeader("Content-Length", file.Length.ToString());
    int offset = 0;
    byte[] buffer = new byte[64 * 1024]; // 64k
    while (Response.IsClientConnected && offset &lt; arquivo.Tamanho)
    {
        DateTime start = DateTime.Now;
        int readCount = file.GetBytes(buffer, offset,
            (int)Math.Min(file.Length - offset, buffer.Length));
        Response.OutputStream.Write(buffer, 0, readCount);
        offset += readCount;
    }
    if(!Response.IsClientConnected)
    {
        // Cancelled by user; do something
    }
}
catch (Exception e)
{
    throw new HttpException(500, e.Message, e);
}
finally
{
    file.Close();
}
