    public class Widget : IComparable
    {
        int x;
        int y;
        public int X
        {
            get { return x; }
            set { x = value; }
        }
        public int Y
        {
            get { return y; }
            set { y = value; }
        }
        public Widget(int argx, int argy)
        {
            x = argx;
            y = argy;
        }
        public int CompareTo(object obj)
        {
            int result = 1;
            if (obj != null && obj is Widget)
            {
                Widget w = obj as Widget;
                result = this.X.CompareTo(w.X);
            }
            return result;
        }
        static public int Compare(Widget x, Widget y)
        {
            int result = 1;
            if (x != null && y != null)                
            {                
                result = x.CompareTo(y);
            }
            return result;
        }
    }
