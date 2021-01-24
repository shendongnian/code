    using System;
    using System.Collections.Generic;
    
    class app
    {
        public static int random_except_list(List<int> openPositions)
        {
            Random r = new Random();
            int index = r.Next(openPositions.Count - 1);
            int result = openPositions[index];
            openPositions.RemoveAt(index);
            return result;
        }
    
        static void Main()
        {
            List<int> openPositions = new List<int>();
    
            for (int i = 1; i < 10; i++)
            {
                openPositions.Add(i);
            }
    
            bool turn = false;
            while (openPositions.Count > 0)
            {
                foreach (int value in openPositions)
                {
                    Console.Write(value + " ");
                }
                Console.WriteLine();
    
                if (!turn)
                {
                    while (true)
                    {
                        Console.WriteLine("Choose your Position");
                        ConsoleKeyInfo key = Console.ReadKey();
                        int num = (int)key.KeyChar - 48;
                        if (openPositions.Contains(num))
                        {
                            openPositions.Remove(num);
                            Console.WriteLine();
                            break;
                        }
                        else Console.Write(" is not Valid: ");
                    }
                }
                else
                {
                    int compPos = random_except_list(openPositions);
                    Console.WriteLine("Computer choose: " + compPos);
                }
                turn = !turn;
            }
            Console.WriteLine("No positions left");
            Console.ReadKey();
        }
    }
