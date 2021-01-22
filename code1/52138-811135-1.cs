    public class Container
    {
        public string name { get; set; }
        public Inner Inner { get; set; }
        public List<Inner> SelectAllInner()
        {
            List<Inner> list = new List<Inner>();
            SelectAllInner(Inner, list);
            return list;
        }
        private void SelectAllInner(Inner inner, List<Inner> list)
        {
            list.Add(inner);
            foreach(Inner inner in MoreInners)
                SelectAllInner(inner, list);
        }
    }
    
    public class Inner
    {
        public string text { get; set; }
        public List<Inner> MoreInners { get; set; }
    }
