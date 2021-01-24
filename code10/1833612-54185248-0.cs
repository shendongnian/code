    public class CatDataView
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int Size { get; set; }
        public int Weight => Age + Size;
    }
