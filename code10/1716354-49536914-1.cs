    class Fun
    {
        int detect;
        int a[2][3];
        void Apply(byte[] ar)
        {
            detect = ar[0];
            for (int i = 0; i < 3; i++)
                a[detect - 1][i] = ar[i];
        }
        public int[] GetAll(int detect)
        {
            int[] ar = new int[3];
            for (int i = 0; i < 3; i++)
                ar[i] = a[detect - 1][i];
            return ar;
        }
        // you can change the get and set methods to properties
        public int A
        {
            get { return a[detect - 1][0]; }
            set { a[detect - 1][0] = value; }
        }
        public int B
        {
            get { return a[detect - 1][1]; }
            set { a[detect - 1][1] = value; }
        }
        public int C
        {
            get { return a[detect - 1][2]; }
            set { a[detect - 1][2] = value; }
        }
    }
