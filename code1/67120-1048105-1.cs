    public static void WriteResourceToDisk(Assembly assembly, 
                                           string resource,
                                           string file)
    {
        using (Stream input = assembly.GetManifestResourceStream(resource))
        {
            if (input == null)
            {
                throw new ArgumentException("Resource name not found");
            }
            using (Stream output = File.Create(file))
            {
                byte[] buffer = new byte[8 * 1024];
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    output.Write(buffer, 0, read);
                }
            }
        }
    }
