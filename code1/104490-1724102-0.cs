    using (var reader = new FileStream(Path.Combine(context.Request.PhysicalApplicationPath, "Data\\test.pdf"), FileMode.Open, FileAccess.Read, FileShare.Read))
    {
        var buffer = new byte[reader.Length];
        reader.Read(buffer, 0, buffer.Length);
        httpResponse.ContentType = "application/pdf";
        httpResponse.BinaryWrite(buffer);
        httpResponse.End();
    }
