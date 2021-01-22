            List<int> lst = new List<int> { 0, 1 };
            for (int i = 0; i <= 10; i++)
            {
                int num = lst.Skip(i).Sum();
                lst.Add(num);
                foreach (int number in lst)
                    Console.Write(number + " ");
                Console.WriteLine();
            }
      
