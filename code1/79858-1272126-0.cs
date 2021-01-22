    const int BUFFER_SIZE = 1024 * 1024;
    var req = WebRequest.Create(imageUrl);
    using (var resp = req.GetResponse())
    {
        using (var stream = resp.GetResponseStream())
        {
            var bytes = new byte[BUFFER_SIZE];
            while (true)
            {
                var n = stream.Read(bytes, 0, BUFFER_SIZE);
                if (n == 0)
                {
                    break;
                }
                context.Response.OutputStream.Write(bytes, 0, n);
            }
        }
    }
