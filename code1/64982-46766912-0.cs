            Console.WriteLine("Enter a number for a");
            int a = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter a number for b");
            int b = int.Parse(Console.ReadLine());
            int Concatenating = Convert.ToInt32(string.Format("{0}{1}", a, b));
            Console.WriteLine(Concatenating);
            Console.ReadKey();
