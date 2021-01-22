    static void Main(string[] args)
            {
                List<int> nums = new List<int>(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 });
                List<int> ids = new List<int>(new int[] { 2, 4, 5 });
    
                for (int i = 0, j = 0; i < nums.Count && j < ids.Count; i++)
                {
                    int num = nums[i];
                    int id = ids[j];
    
                    if (num == id)
                    {
                        Console.WriteLine("Match = " + id);
                        j++;
                    }
                }
    
                Console.ReadLine();
            }
