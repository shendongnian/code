            List<int> numberList = new List<int>();
            List<int> uniqueList = new List<int>();
            string input;
            int number = 0;
            bool over = false;
            while (!over)
            {
                input = Console.ReadLine();
                if (input == "quit")
                {
                    over = true;
                    //break; // it is not needed since you have over = true
                }
                if (int.TryParse(input, out number))
                {
                    numberList.Add(number);
                }
            }
            for (int i = 0; i < numberList.Count; i++)
            {
                //if (!uniqueList.Contains(number)) // this is the wrong line
                if (numberList.Count(q => q == numberList[i]) == 1)
                {
                    //uniqueList.Add(number); // this is also wrong
                    uniqueList.Add(numberList[i]);
                }
            }
            for (int i = 0; i < uniqueList.Count; i++)
            {
                Console.WriteLine(uniqueList[i]);
            }
            Console.ReadKey();
