    public class MyClass {
        [ReadOnly]
        public string FileAuthor { get; set; }
        public string MetaDataAuthor { 
           get { return _metaDataAuthor; }
           set {  _metaDataAuthor = value; }
        }
        private string  _metaDataAuthor;
    }
