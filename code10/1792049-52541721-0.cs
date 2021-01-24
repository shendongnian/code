    class CheckItem
    {
        static readonly string myNumber = "5784230137691";
        static int[] firstTwelveList = new int[12];
        static int[] arrayEvenPosition = new int[(myNumber.Length / 2)];
        static int[] arrayOddPosition = new int[(myNumber.Length / 2)];
        static int idx = 0;
        static int evenIdx = 0; // track current index of new array
        public static void Position()
        {
            firstTwelveList = myNumber.Substring(0, 12).Select(c => c - '0').ToArray();
            foreach (var even in firstTwelveList)
            {
                if (Array.IndexOf(firstTwelveList, even) % 2 == 0) // replace idx with even...
                {
                    Array.Copy(firstTwelveList, idx, arrayEvenPosition, evenIdx, 1); // copy the element from the current index of first array to new array
                    evenIdx++;
                }
                idx++;
            }
            Console.ReadLine();
        }
    }
