    public class Menu
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<MenuItem> SubItems { get; set; }
    }
    public class MenuItem
    {
        public string Header { get; set; }
        public string Name { get; set; }
        public List<MenuItem> SubItems { get; set; }
    }
