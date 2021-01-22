    public class PostData
    {
        public PostData() { Fields = new List<IPostDataField>(); }
        public List<IPostDataField> Fields { get; set; }
        public Byte[] Export(out string boundary)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                Random r = new Random();
                string tok = "";
                for (int i = 0; i < 14; i++)
                    tok += r.Next(10).ToString();
                boundary = "---------------------------" + tok;
                using (StreamWriter sw = new StreamWriter(stream))
                {
                    //sw.WriteLine(string.Format("Content-Type: multipart/form-data; boundary=" + boundary.Replace("--", "")));
                    //sw.WriteLine();
                    //sw.Flush();
                    foreach (IPostDataField field in Fields)
                    {
                        sw.WriteLine("--" + boundary);
                        sw.Flush();
                        stream.Write(field.Export(), 0, (int)field.Export().Length);
                    }
                    //1 keer om het af te leren
                    //sw.WriteLine();
                    sw.WriteLine("--" + boundary + "--");
                    sw.Flush();
                    stream.Position = 0;
                    using (StreamReader sr = new StreamReader(stream))
                    {
                        string bla = sr.ReadToEnd();
                        stream.Position = 0;
                        Byte[] toExport = new Byte[stream.Length];
                        stream.Read(toExport, 0, (int)stream.Length);
                        return toExport;
                    }
                }
            }
        }
    }
