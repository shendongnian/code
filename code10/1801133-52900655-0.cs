    Console.WriteLine("input array of numbers: ");
            List<int> uniqueInts = new List<int>();
            int[] array = new int[4];
            for (int i = 0; i < 3; i++)
            {
                array[i] = int.Parse(Console.ReadLine());
                if (!uniqueInts.Contains(array[i]))
                    uniqueInts.Add(array[i]);
            }
            //getting the max number
            //assuming the first number is the max
            int max = uniqueInts[0];
            
            for (int i = 1; i < uniqueInts.Count; i++)
            {
                if (max < uniqueInts[i])
                    max = uniqueInts[i];
            }
            Console.WriteLine("The highest number is : " + max);
 
