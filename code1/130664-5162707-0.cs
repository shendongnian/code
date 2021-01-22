        one,
        two,
        three
    };
    class EnumStringToInt
    {
        static void Main()
        {
            Numbers num = Numbers.one; // converting enum to string
            string str = num.ToString();
            //Console.WriteLine(str);
            string str1 = "four";
            string[] getnames = (string[])Enum.GetNames(typeof(Numbers));
            int[] getnum = (int[])Enum.GetValues(typeof(Numbers));
            try
            {
                for (int i = 0; i <= getnum.Length; i++)
                {
                    if (str1.Equals(getnames[i]))
                    {
                        Numbers num1 = (Numbers)Enum.Parse(typeof(Numbers), str1);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Value not found!", ex);
            }
        }
    }
