    public class StringCleaner
    {
        private readonly string dirtyString;
    
        public StringCleaner(string dirtyString)
        {
            this.dirtyString = dirtyString;
        } 
    
        public string Clean()
        {
            using (var sw = new System.IO.StringWriter())
            {
                foreach (char c in dirtyString)
                {
                    if (c != '\\') sw.Write(c);
                }
                
                return sw.ToString();
            }
        }
    }
