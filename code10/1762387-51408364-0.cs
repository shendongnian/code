    public class test
    {
        public string[] content ={
            "Username:Peter",
            "ID:1",
            "Username:Nike",
            "ID:2"};
        public Dictionary<string, string> contents;
        public Dictionary<string, string> Contents
        {
            get
            {
                if (contents == null)
                {
                    InitContents();
                }
                return contents;
            }
        }
        private void InitContents()
        {
            contents = new Dictionary<string, string>();
            for (var i = 0; i < content.Length; i++)
            {
                contents.Add(GetValue(content[i]), GetValue(content[i + 1]));
                i++;
            }
        }
        private string GetValue(string data)
        {
            return data.Substring(data.IndexOf(":", StringComparison.Ordinal) + 1);
        }
        public IEnumerable<string> GetContents()
        {
            return Contents.Select(x => "Name: " + x.Key + " ID:" + x.Value);
        }
       
    }
