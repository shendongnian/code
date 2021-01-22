        public Form1()
        {
            InitializeComponent();
            int[] a = { 4, 5, 6, 7, 8 };
            unsafe
            {
                fixed (int* c = a)
                {
                    SubArrayPointer(c + 3);
                }
            }
            SubArray(a, 3);
        }
        unsafe void SubArrayPointer(int* d)
        {
            MessageBox.Show(string.Format("Using pointer, outputs 7 --> {0}", d[0]));
        }
        void SubArray(int[] d, int offset)
        {
            MessageBox.Show(string.Format("Using offset, outputs 7 --> {0}", d[offset]));
        }
