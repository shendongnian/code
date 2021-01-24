                int count = 0;
                for(int i = 0; i < myint.Length; i++)
                {
                    if (myint[i].Equals(b))
                        count++;
                }
                Console.WriteLine((double)count / (double)myint.Length);
