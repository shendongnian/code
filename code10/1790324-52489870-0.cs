            var sw = new Stopwatch();
            sw.Start();
            var test_matrix = Matrix<double>.Build.Dense(1000, 1000, 0);
            double finding_Element = 1;
            test_matrix[999, 999] = finding_Element;
            test_matrix[998, 999] = finding_Element;
            var result = new List<ValueTuple<int, int>>();
            
            for (int row = 0; row < 1000; row++)
            {
                for (int column = 0; column < 1000; column++)
                {
                    if (test_matrix[row, column] == finding_Element)
                    {
                        result.Add(new ValueTuple<int, int>(row, column));
                    }
                }
            }
            sw.Stop();
            Console.WriteLine("Find List of Result: " + sw.ElapsedMilliseconds + "ms");
            var sw1 = new Stopwatch();
            sw1.Start();
            var result2 = test_matrix.Find(x => x.Equals(finding_Element)); // First Value
            sw1.Stop();
            Console.WriteLine("Find First Occurence: " + sw.ElapsedMilliseconds + "ms");
            Console.ReadLine();
