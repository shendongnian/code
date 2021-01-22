                string sample = "23232-2222-d23231";
                StringBuilder resultBuilder = new StringBuilder(sample.Length);
                char c;
                for (int i = 0; i < sample.Length; i++)
                {
                    c = sample[i];
                    if (c >= '0' && c <= '9')
                    {
                        resultBuilder.Append(c);
                    }
                }
                Console.WriteLine(resultBuilder.ToString());
                Console.ReadLine();
