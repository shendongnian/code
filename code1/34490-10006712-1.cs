            string Name = "Very good nice one is very good but is very good nice one this is called the term";
            bool valid=true;
            int count = 0;
            int k=0;
            int m = 0;
            while (valid)
            {
                k = Name.Substring(m,Name.Length-m).IndexOf("good");
                if (k != -1)
                {
                    count++;
                    m = m + k + 4;
                }
                else
                    valid = false;
            }
            Console.WriteLine(count + " Times accures");
