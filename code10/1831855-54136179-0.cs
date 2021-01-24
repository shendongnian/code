    public static class XmlReaderExtensions
    {
        public static bool ReadToAndCopyBase64ElementContentsToFile(this XmlReader reader, string localName, string namespaceURI, string path)
        {
            if (!reader.ReadToFollowing(localName, namespaceURI))
                return false;
            return reader.CopyBase64ElementContentsToFile(path);
        }
        public static bool CopyBase64ElementContentsToFile(this XmlReader reader, string path)
        {
            using (var stream = File.Create(path))
            {
                byte[] buffer = new byte[8192];
                int readBytes = 0;
                while ((readBytes = reader.ReadElementContentAsBase64(buffer, 0, buffer.Length)) > 0)
                {
                    stream.Write(buffer, 0, readBytes);
                }
            }
            return true;
        }
    }
