                List<int> factorList = new List<int>();
                int[] numArray = new int[] { 1, 0, 6, 9, 7, 5, 3, 6, 0, 8, 1 };
                foreach (int item in numArray)
                {
                    for (int x = 1; x <= item; x++)
                    {
                      //check for the remainder after dividing for each number less that number
                        if (item % x == 0)
                        {
                            factorList.Add(x);
                        }
                    }
                    if (factorList.Count == 2) // has only 2 division factores ; prime number
                    {
                        Console.WriteLine(item + " is a prime number ");
                    }
                    else
                    {Console.WriteLine(item + " is not a prime number ");}
                    factorList = new List<int>(); // reinitialize list
                }
