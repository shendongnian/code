    class Matrix4
    {
        private double[,] _m = new double[4, 4] { { 1, 0, 0, 0 }, { 0, 1, 0, 0 }, { 0, 0, 1, 0 }, { 0, 0, 0, 1 } };
        public double this[int i,int j]
        {
            get { return (_m[i,j]); }
            set { _m[i,j] = value; }
        }
    }
    var m4 = new Matrix4();
    // m4[1,1] == 1
