        static void Main(string[] args)
        {
            //int[] arr = new int[10] { 9, 4, 6, 2, 11, 100, 53, 23, 72, 81 };
            int[] arr = { 1, 8, 4, 5, 12, 2, 5, 6, 7, 1, 90, 100, 56, 8, 34 };
            int MaxNum = 0;
            int SecNum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > MaxNum)
                {
                    if (MaxNum > SecNum) { SecNum = MaxNum; }
                    MaxNum = arr[i];
                }
                if (arr[i] < MaxNum && arr[i] > SecNum)
                {
                    SecNum = arr[i];
                }
                
            }
            Console.WriteLine("Highest Num: {0}. Second Highest Num {1}.", MaxNum, SecNum);
            Console.ReadLine();
        }
