    public class CustomStringComparer : IComparer<string>
    {
        List<string> templates = new List<string> { "House", "Vehicle", "Electric" };
        public int Compare(string x, string y)
        {
            string xTemplate = templates.FirstOrDefault(t => x.Contains(t));
            string yTemplate = templates.FirstOrDefault(t => y.Contains(t));
            int xTemplateIndex = templates.IndexOf(xTemplate);
            int yTemplateIndex = templates.IndexOf(yTemplate);
            return xTemplateIndex.CompareTo(yTemplateIndex);
        }
    }
