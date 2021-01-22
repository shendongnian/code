       static void Main(string[] args)
                {
                    int sum = 0;
                    for (int i = 1; i <= 7; i++)
                    {
                        int c = fact(i);
                        sum += c;
                        Console.WriteLine("Factorial is : " + c);
                        Console.ReadLine();
                        Console.WriteLine("By Adding.. will give " + sum);
        
                    }
                }
                static int fact(int value)
                {
                    if (value ==1)
                    {
                        return 1;
                    }
                    else
                    {
                        return (value * (fact(value - 1)));
                    }
                }
