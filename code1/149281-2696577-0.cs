    public class X
    {
        private Y _y;
        public Y Y
        {
            get { return _y; }
            set
            {
                if (_y != value)
                {
                    Y temp = _y;
                    _y = value;
                    // If new value is not null
                    if (_y != null)
                    {
                        _y.X = this;
                    }
                    // If old value is not null but new value is 
                    else if (temp != null)
                    {
                        temp.X = null;
                    }
                }
            }
        }
    }
    public class Y
    {
        private X _x;
        public X X
        {
            get { return _x; }
            set
            {
                if (_x != value)
                {
                    X temp = _x;
                    _x = value;
                    // If new value is not null
                    if (_x != null)
                    {
                        _x.Y = this;
                    }
                    // If old value is not null but new value is 
                    else if (temp != null)
                    {
                        temp.Y = null;
                    }
                }
            }
        }
    }
