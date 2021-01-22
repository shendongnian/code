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
