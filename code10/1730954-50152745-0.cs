                int[] AL = { 4, 3, 2, 1 };
                for (int i = 1; i < AL.Count(); i++)
                {
                    for (int j = i; j > 0; j--)
                    {
                        if (AL[j-1] < AL[j])
                        {
                            int temp = AL[j -1];
                            AL[j - 1] = AL[j];
                            AL[j] = temp;
                        }
                        Console.WriteLine("i = '{0}', j = '{1}', array = '{2}'", i.ToString(), j.ToString(),string.Join(",", AL.Select(x => x.ToString())));
                    }
                }
                Console.ReadLine();
