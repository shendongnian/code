    public class PostDataField : IPostDataField
    {
        public string Name { get; set; }
        public string Value { get; set; }
        #region IPostDataField Members
        public byte[] Export()
        {
            using (MemoryStream stream = new MemoryStream())
            {
                StreamWriter sw = new StreamWriter(stream);
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine(string.Format("Content-Disposition: form-data; name=\"{0}\"", Name));
                    sb.AppendLine();
                    sb.AppendLine(Value);
                    sw.Write(sb.ToString());
                    sw.Flush();
                }
                stream.Position = 0;
                byte[] buffer = new byte[stream.Length];
                stream.Read(buffer, 0, (int)buffer.Length);
                return buffer;
            }
        }
        #endregion
    }
