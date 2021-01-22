        using (MemoryStream ms = new MemoryStream())
        {
            using (GZipStream gzip = new GZipStream(ms, CompressionMode.Compress, true))
            {
                byte[] raw = Encoding.UTF8.GetBytes(longString);
                gzip.Write(raw, 0, raw.Length);
                gzip.Close();
            }
            byte[] zipped = ms.ToArray(); // as a BLOB
            string base64 = Convert.ToBase64String(zipped); // as a string
            // store zipped or base64
        }
