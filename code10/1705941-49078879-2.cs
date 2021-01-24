    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<MySection>();
            list.Add(new MySection()
            {
                Items = new List<MyItem>()
                {
                    new MyItem() { Name = "One", Text = "Two", Value = "Three" }
                }
            });
            // can access value here: list.First().Items.First().Value
            IEnumerable<ISection<TemplateItem>> genericList = list;
            foreach (ISection<TemplateItem> genericSection in genericList) 
            {
                // no value here
            }
        }
    }
    public interface ISection<out T> where T : TemplateItem
    {
        string Name { get; }
        IEnumerable<T> Items { get; }
    }
    
    public class TemplateSection<T> : ISection<T> where T : TemplateItem
    {
        public string Name { get; set; }
        public List<T> Items { get; set; }
        IEnumerable<T> ISection<T>.Items => Items;
    }
    public class TemplateItem
    {
        public string Name { get; set; }
        public string Text { get; set; }
    }
    public class MySection : TemplateSection<MyItem>
    {        
        
    }
    public class MyItem : TemplateItem
    {
        public string Value { get; set; }
    }
