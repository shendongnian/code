    public class TreeViewModel
    {
        public TreeViewModel()
        {
            this.Height = 200;
        }
        
        private int _Height = 200;
        public int Height 
        {
           get { return _Height; }
           set
           {
               int minHeight = 200;
               this.Height = value < minHeight ? minHeight : value;
           }
        }
    }
