    public class MyObj
    {
        private RectangleF mRectangle;
        public event EventHandler RectangleChanged;
        public RectangleF Rectangle
        {
            get
            {
                return mRectangle;
            }
            set
            {
                mRectangle = value;
                OnRectangleChanged();
            }
        }
        protected virtual void OnRectangleChanged()
        {
            if (RectangleChanged != null)
            {
                RectangleChanged(this, EventArgs.Empty);
            }
        }
    }
