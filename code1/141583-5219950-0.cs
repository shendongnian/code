    public class Img : Image
    {
        public Img()
        {
            RelativePath = false;
        }
        public bool RelativePath { get; set; }
        public override string ImageUrl
        {
            get
            {
                if (RelativePath)
                    return base.ImageUrl;
                return "http://some.configurable-value.com" + base.ImageUrl;
            } 
            set { base.ImageUrl = value; }
        }
    }
