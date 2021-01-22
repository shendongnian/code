            List<int> nums = new List<int>();
            for (int i = 0; i < 100; i++)
            {
                nums.Add(i);
            }
            for (int i = nums.Count-1; i >= 0; i--)
            {
                if (i % 2 == 0)
                {
                    nums.RemoveAt(i); 
                }
            }
            foreach (int i in nums)
            {
                Console.WriteLine(i);
            }
            Console.ReadKey();
