            int[] myArray = new int[] { 2, 4, 3, 6, 9 };
            int max1 = 0;
            int max2 = 0;
            for (int i = 0; i < myArray.Length; i++)
            {
                if (myArray[i] > max1)
                {
                    max2 = max1;
                    max1 = myArray[i];
                }
                else
                {
                    max2 = myArray[i];
                }
            }
            Console.WriteLine("first" + max1.ToString());
            Console.WriteLine("Second" + max2.ToString());
            Console.ReadKey();
