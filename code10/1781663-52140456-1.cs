    internal class RectAdapter
    {  
        private Rect _rect;
 
        public RectAdapter(Rectangle rect)
        {
            _rect = rect;
        }
        public Point TopLeft
        {
            get
            {
                return new Point(_rect.X, _rect.Y);
            }
        }
    
        public Point TopRight
        {
            get
            {
                return new Point(_rect.X + _rect.Width, _rect.Y);
            }
        }
    }
