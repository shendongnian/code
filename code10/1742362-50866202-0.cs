    public class Person
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public virtual Image Image { get; set; }
    }
    
    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public virtual Image Image { get; set; }
    }
    
    public class Image
    {
        public int ImgID { get; set; } // Named for distinction
        public string Url { get; set; }
    }
