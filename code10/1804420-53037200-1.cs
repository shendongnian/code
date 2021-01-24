            string tobesorted;
            string encoded = "";
            int temp1
            int same = 1;
            Console.WriteLine("Please enter the string you want to be sorted");
            tobesorted = Console.ReadLine();
            tobesorted = tobesorted.ToUpper();
            tobesorted = tobesorted.Replace(" ", string.Empty);
            char[] tbsarray = tobesorted.ToCharArray();
            for (int i = 0; i < tbsarray.Length; i++)
            {
                temp1 = tbsarray[i];
         
                encoded = encoded + tbsarray[i];
                encoded = encoded + Convert.ToString(same);
                same = 1;
                
                if ((tbsarray.Length - 2 == i))
                {
                    encoded = encoded + tbsarray[i] + Convert.ToString(same);
                    Console.WriteLine(encoded);
                }
            }
            Console.WriteLine(encoded);
            Console.ReadLine();
