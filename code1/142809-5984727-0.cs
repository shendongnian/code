    public class Product
    {
        public Product()
        {
            PhotoCollection = new Collcation<Photo>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        protected virtual ICollection<Photo> PhotoCollection {get; set; }
    
        public IEnumerable<Photo> Photos
        {
            get { return PhotoCollection ; } 
        }
    
        public void AddPhoto(Photo photo)
        {
            //Some biz logic
            //...
            PhotoCollection .Add(photo);
        }
    }
