    class myText
    {
        public List<string> Lines;
    
        public string GetList()
        {
            StringBuilder sb = new StringBuilder();
            int i = 0;
            foreach (string s in Lines)
            {
                sb.AppendFormat("{0}: {1}", i, s).AppendLine();
                i++;
            }
            return sb.ToString();
        }
    }
