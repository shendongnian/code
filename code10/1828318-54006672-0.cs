            int value = 0;
            List<int> list = new List<int> { 1, 2, 3, 4 }; // choices are in the list
            while (true)
            {
                Console.WriteLine("Please enter a number :");
                if (int.TryParse(Console.ReadLine(), out value))
                {
                    if (list.Contains(value))
                        break;
                }
            }
            // value is in the list, deal with it.
