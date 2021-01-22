    class MyObject
    {
        string beginningFile;
        string location;
        string[] files;
        int[] count;
    
        public MyObject(string input)
        {
            string[] barSplit = input.Split(new char[1] { '|' }, StringSplitOptions.RemoveEmptyEntries);
    
            beginningFile = barSplit[0];
            location = barSplit[1];
    
            string[] semiSplit = barSplit[2].Split(new char[1] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            List<string> f = new List<string>();
            List<int> c = new List<int>();
            Regex r = new Regex(@"\{(\d+)\-(\d+)\}");
    
            foreach (string s in semiSplit)
            {
                f.Add(s.Trim());
    
                if (s.Contains("{"))
                {
                    Match m = r.Match(s);
                    int x = Convert.ToInt32(m.Groups[2].Value) - Convert.ToInt32(m.Groups[1].Value) + 1;
                    c.Add(x);
                }
                else
                {
                    c.Add(1);
                }
            }
    
            files = f.ToArray();
            count = c.ToArray();
        }
    
        public override string ToString()
        {
            string text = "";
    
            for(int i = 0; i < files.Length; i++)
            {
                text += string.Format("{0}|{1}|{2}|{3}\n", beginningFile, location, files[i], count[i]);
            }
    
            return text;
        }
    }
