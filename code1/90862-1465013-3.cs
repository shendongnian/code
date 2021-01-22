    public class TreeViewModel
    {
        private const int minHeight = 200;
        private int _Height = minHeight;
        public int Height 
        {
           get { return _Height; }
           set { this.Height = value < minHeight ? minHeight : value; }
        }
    }
