        public static string RandomString(Random rand, int length)
        {
            char[] str = new char[length];
            for (int i = 0; i < length; i++)
            {
                if (i % 2 == 0)
                {    //letters
                    str[i] = (char)rand.Next(65, 90);
                }
                else
                {
                    //numbers 
                    str[i] = (char)rand.Next(49, 57);
                }
            }
            return new string(str);
        }
