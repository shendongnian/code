    public class NavBarItem
    {
        public NavBarItem()
        {
            Childs = new List<NavBarItem>();
        }
        public int ID { get; set; }
        public int? ParentID { get; set; }
        public string Text { get; set; }
        public List<NavBarItem> Childs { get; set; }
        public override string ToString()
        {
            return Text;
        }
    }
