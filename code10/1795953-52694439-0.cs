            static void Main(string[] args)
            {
                Parse("1");
                Parse("-1");
                Parse("DDD");
            }
            private static void Parse(string x)
            {
                if (decimal.TryParse(x, out decimal weight))
                {
                    if (weight > 0)
                    {
                        var weightcost = 2 * weight;
                        Console.WriteLine(weightcost.ToString("c"));
                    }
                    else
                    {
                        Console.WriteLine("Weight must be greater than 0.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input for weight.");
                }
            }
