    public static class Extensions {
        public static async Task<byte[]> ReadAllBytes(this BinaryReader reader)
        {
            const int bufferSize = 4096;
            using (var ms = new MemoryStream())
            {
                byte[] buffer = new byte[bufferSize];
                int count;
                while ((count = reader.Read(buffer, 0, buffer.Length)) != 0) {
                    await ms.WriteAsync(buffer, 0, count);
                }
                return ms.ToArray();
            }
        }
    }
