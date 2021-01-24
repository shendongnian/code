            var number = new int[5];
            Console.WriteLine("Enter 5 unique numbers");
            for (int i = 0; i < 5; i++)
            {
                while (true)
                {
                    var newValue = Convert.ToInt32(Console.ReadLine());
                    var currentNumber = Array.IndexOf(number, newValue);
                    if (currentNumber == -1)
                    {
                        number[i] = newValue; // Accept New value
                        break;
                    }
                    Console.WriteLine("Hold on, you already entered that number. Try again.");
                }
            }
            Array.Sort(number);
            Console.WriteLine();
            foreach (var n in number)
                Console.WriteLine(n);
            Console.ReadLine();
