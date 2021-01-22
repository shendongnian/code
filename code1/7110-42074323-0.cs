            int[] numbers = {0,1,2,3,4,5,6,7,8,9};
            List<int> numList = new List<int>();
            numList.AddRange(numbers);
            Console.WriteLine("Original Order");
            for (int i = 0; i < numList.Count; i++)
            {
                Console.Write(String.Format("{0} ",numList[i]));
            }
            Random random = new Random();
            Console.WriteLine("\n\nRandom Order");
            for (int i = 0; i < numList.Capacity; i++)
            {
                int randomIndex = random.Next(numList.Count);
                Console.Write(String.Format("{0} ", numList[randomIndex]));
                numList.RemoveAt(randomIndex);
            }
            Console.ReadLine();
