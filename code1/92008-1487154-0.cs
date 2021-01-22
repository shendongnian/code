    public sealed class StringJoiningList
    {
        private readonly List<string> list = new List<string>();
       
        public void Add(string item)
        {
            list.Add(item);
        }
        public override string ToString()
        {
            return string.Join(", ", list.ToArray());
        }
    }
    
