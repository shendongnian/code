    public class ImageList
    {
        public string image_name { get; set; }
        public string image_url { get; set; }
        public string image_description { get; set; }
    }
    
    public class ProductModel 
    {
        public List<ImageList> image_list { get; set; }
    }
