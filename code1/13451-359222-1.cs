    public class PostData
    {
        // Change this if you need to, not necessary
        public static string boundary = "AaB03x";
        private List<PostDataParam> m_Params;
        public List<PostDataParam> Params
        {
            get { return m_Params; }
            set { m_Params = value; }
        }
        public PostData()
        {
            m_Params = new List<PostDataParam>();
        }
        /// <summary>
        /// Returns the parameters array formatted for multi-part/form data
        /// </summary>
        /// <returns></returns>
        public string GetPostData()
        {
            StringBuilder sb = new StringBuilder();
            foreach (PostDataParam p in m_Params)
            {
                sb.AppendLine("--" + boundary);
                if (p.Type == PostDataParamType.File)
                {
                    sb.AppendLine(string.Format("Content-Disposition: file; name=\"{0}\"; filename=\"{1}\"", p.Name, p.FileName));
                    sb.AppendLine("Content-Type: application/octet-stream");
                    sb.AppendLine();
                    sb.AppendLine(p.Value);
                }
                else
                {
                    sb.AppendLine(string.Format("Content-Disposition: form-data; name=\"{0}\"", p.Name));
                    sb.AppendLine();
                    sb.AppendLine(p.Value);
                }
            }
            sb.AppendLine("--" + boundary + "--");
            return sb.ToString();
        }
    }
    public enum PostDataParamType
    {
        Field,
        File
    }
    public class PostDataParam
    {
        public PostDataParam(string name, string value, PostDataParamType type)
        {
            Name = name;
            Value = value;
            Type = type;
        }
        public PostDataParam(string name, string filename, string value, PostDataParamType type)
        {
            Name = name;
            Value = value;
            FileName = filename;
            Type = type;
        }
        public string Name;
        public string FileName;
        public string Value;
        public PostDataParamType Type;
    }
