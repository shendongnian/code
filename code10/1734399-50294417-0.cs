    public static int addTwoDigits(int n)
        {
            string number = n.ToString();
            char[] a = number.ToCharArray();
            int total = 0;
            for (int i = 0; i < a.Length; i++)
            {
                total = total + (int)Char.GetNumericValue(a[i]);
            }
            return total;
        }
