    public static byte[] ReadResource(string resourceName)
    {
        using (Stream s = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName))
        {
            byte[] buffer = new byte[1024];
            using (MemoryStream ms = new MemoryStream())
            {
                while (true)
                {
                    int read = s.Read(buffer, 0, buffer.Length);
                    if (read <= 0)
                        return ms.ToArray();
                    ms.Write(buffer, 0, read);
                }
            }
        }
    }
