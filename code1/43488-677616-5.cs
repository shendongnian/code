        static void problem16a()
        {
            const int limit = 1000;
            int ints = limit / 29;
            int[] number = new int[ints + 1];
            number[0] = 2;
            for (int i = 2; i <= limit; i++)
            {
                doubleNumber(number);
            }
            String text = NumberToString(number);
            Console.WriteLine(text);
            Console.WriteLine("The sum of digits of 2^" + limit + " is " + sumDigits(text));
        }
        static void doubleNumber(int[] n)
        {
            int carry = 0;
            for (int i = 0; i < n.Length; i++)
            {
                n[i] <<= 1;
                n[i] += carry;
                if (n[i] >= 1000000000)
                {
                    carry = 1;
                    n[i] -= 1000000000;
                }
                else
                {
                    carry = 0;
                }
            }
        }
        static String NumberToString(int[] n)
        {
            int i = n.Length;
            while (i > 0 && n[--i] == 0)
                ;
            String ret = "" + n[i--];
            while (i >= 0)
            {
                ret += String.Format("{0:000000000}", n[i--]);
            }
            return ret;
        }
