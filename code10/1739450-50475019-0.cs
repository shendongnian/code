    public class PopulateNamesEventArgs : EventArgs
    {
        private List<string> names = new List<string>();
        public string[] Names => names.ToArray();
        public void AddName(string name) => names.Add(name);
    }
