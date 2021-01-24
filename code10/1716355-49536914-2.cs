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
        GetA(int detect)
        {
            return a[detect - 1][0];
        }
        SetA(int detect, int val)
        {
            a[detect - 1][0] = val;
        }
        GetB(int detect)
        {
            return a[detect - 1][1];
        }
        SetB(int detect, int val)
        {
            a[detect - 1][1] = val;
        }
        GetC(int detect)
        {
            return a[detect - 1][2];
        }
        SetC(int detect, int val)
        {
            a[detect - 1][2] = val;
        }
    }
