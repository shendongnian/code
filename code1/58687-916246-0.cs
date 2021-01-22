    public partial class LinqClass
    {
        public string ImagePath { get; set; }
        public System.Drawing.Image Picture
        {
            get
            {
                return System.Drawing.Image.FromFile(ImagePath);
            }
        }
    }
