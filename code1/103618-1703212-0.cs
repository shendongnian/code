                double count = 0.0;
                double min = double.MaxValue;
                double max = double.MinValue;
                double total = 0.0;
                using(StreamReader sr = new StreamReader(@"c:\data.txt"))
                {
                    while (!sr.EndOfStream)
                    {
                        String line = sr.ReadLine();
                        double value = double.Parse(line.Trim());
                        if (value < min) min = value;
                        if (value > max) max = value;
                        total += value;
                        count++;
                    }
                }
    
                Console.WriteLine("Min: {0}", min);
                Console.WriteLine("Max: {0}", max);
                Console.WriteLine("Avg: {0}", (total / count).ToString("0.00"));
                Console.ReadLine();
