                while (true)
                {
                    try
                    {
                        fahrenheit = int.Parse(Console.ReadLine());
                        break;
                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine("Endast heltal kan matas in, försök igen!");
                        Console.WriteLine("\nSkriv in Fahrenheit grader: ");
                    }
                }
