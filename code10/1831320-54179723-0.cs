           var file = @"D:\\awaisFile.csv";
            using (var stream = File.AppendText(file))
            {
                /* initialize elements of array n */
                for (i = 0; i < num1.Count(); i++)
                {
                    Console.Write("Enter value of 'num1'");
                    Console.WriteLine(i + 1);
                    num1[i] = int.Parse(Console.ReadLine());
                    temp1[i] = num1[i].ToString();
                    Console.Write("Enter value of 'num2'");
                    Console.WriteLine(i + 1);
                    num2[i] = int.Parse(Console.ReadLine());
                    temp2[i] = num2[i].ToString();
                    res[i] = multiplyNum(num1[i], num2[i]);
                    Console.WriteLine("Element1[{0}] = {1}", i, res[i]);
                    temp3[i] = res[i].ToString();
                    string csvRow = string.Format("{0},{1},{2}", temp1[i], temp2[i], temp3[i]);
                    stream.WriteLine(csvRow);
                }
            }
