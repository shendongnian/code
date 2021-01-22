    public class PostDataFile : IPostDataField
    {
        public Byte[] Content { get; set; }
        public string Name { get; set; }
        public string FileName { get; set; }
        public string Type { get; set; } // mime type
        public byte[] Export()
        {
            using (MemoryStream stream = new MemoryStream())
            {
                StreamWriter sw = new StreamWriter(stream);
                StringBuilder sb = new StringBuilder();
                sb.AppendLine(string.Format("Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"", Name, FileName));
                sb.AppendLine("Content-Type: " + Type);
                sb.AppendLine();
                sw.Write(sb.ToString());
                sw.Flush();
                stream.Write(Content, 0, Content.Length);
                stream.Position = 0;
                byte[] buffer = new byte[stream.Length];
                stream.Read(buffer, 0, (int)buffer.Length);
                return buffer;
            }
        }
    }
