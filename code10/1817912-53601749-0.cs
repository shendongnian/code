         int userInInt, userIntStart;
            Console.Write("How many integers do you want to print? ");
            userInInt = Int32.Parse(Console.ReadLine());
            Console.Write("What is the first integer you want printed? ");
            userIntStart = Int32.Parse(Console.ReadLine());
            int i = 0;
            for (int counts = userIntStart; i<userInInt; counts++,i++)
            {
                Console.WriteLine(counts);
            }
            Console.ReadLine();
