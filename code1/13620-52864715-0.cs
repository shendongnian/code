    public static class StreamHelpers
    {
        public static byte[] ReadFully(this Stream input)
        {
            var ms = new MemoryStream();
            input.CopyTo(ms);
            return ms.ToArray();
        }
    }
