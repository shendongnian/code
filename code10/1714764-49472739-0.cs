            int[] nums = new int[3];
            for (int i = 0; i < 3; i++)
                Console.WriteLine("Enter job number");
                int num = Convert.ToInt32(Console.ReadLine());
                while (nums.Contains(num))
                {
                    Console.WriteLine("Sorry, the job number " + num + " is a duplicate. \nPlease reenter: ");
                    num = Convert.ToInt32(Console.ReadLine());
                }
                nums[i] = num;
