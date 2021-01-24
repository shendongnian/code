     class Matrix4
        {
            private double[,] _m = new double[4, 4] { { 1, 0, 0, 0 }, { 0, 1, 0, 0 }, { 0, 0, 1, 0 }, { 0, 0, 0, 1 } };
            public double this[int x, int y]
            {
                get { return (_m[x, y]); }
                set { _m[x, y] = value; }
            }
        }
