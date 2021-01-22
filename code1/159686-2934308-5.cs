    using (Stream output = File.OpenWrite("file.dat"))
    using (Stream input = http.Response.GetResponseStream())
    {
        byte[] buffer = new byte[8192];
        int bytesRead;
        while ((bytesRead = input.Read(buffer, 0, buffer.Length)) > 0)
        {
            output.Write(buffer, 0, bytesRead);
        }
    }
