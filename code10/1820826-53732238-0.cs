    int number = 0, sum = 0, count = 0;
            while (number < 5)
            {
                Console.Write("Input Number {0} : " , (number + 1));
                int mark = Convert.ToInt16(Console.ReadLine());
                if (mark < 50)
                {
                    count++;
                }
                if (count == 2)
                {
                    Console.WriteLine("\nStop\n");
                    break;
                }
                sum += mark;
                number++;
            }
            if (count <= 1)
            {
                Console.WriteLine("\nsum = {0}\nPassed\n",sum);
            }
