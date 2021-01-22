        void Test()
        { 
            // Note: 10 is the maximum number of digits.
            int[] xs = new int[10];
            System.Random r = new System.Random();
            for (int i=0; i < 10000000; ++i)
                Convert(xs, r.Next(int.MaxValue));
        }
        // Notice, I don't allocate and return an array each time.
        public void Convert(int[] digits, int val)
        {
            for (int i = 0; i < 10; ++i)
            {
                digits[10 - i] = val % 10;
                val /= 10;
            }
        }
