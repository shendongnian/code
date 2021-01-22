                private static int _x=0, _y=0;
            private static Point _point;
            public static Point LocationInForm(Control c)
            {
                if (c.Parent == null) 
                {
                    _x += c.Location.X;
                    _y += c.Location.Y;
                    _point = new Point(_x, _y);
                    _x = 0; _y = 0;
                    return _point;
                }
                else if ((c.Parent is System.Windows.Forms.Form))
                {
                    _point = new Point(_x, _y);
                    _x = 0; _y = 0;
                    return _point;
                }
                else 
                {
                    _x += c.Location.X;
                    _y += c.Location.Y;
                    LocationInForm(c.Parent);
                }
                return new Point(1,1);
            }
