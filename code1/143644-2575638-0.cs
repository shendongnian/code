        static List<int> idList = new List<int>() { 1, 2, 4, 5, 6, 8, 9 };
        private static void moveList(int index)
        {
            int getIndex = 0;
            foreach (int item in idList)
            {
                Console.WriteLine(" Before Id List Value - {0} ,Index - {1} ", item.ToString(), getIndex);
                getIndex++;
            }
            int value = idList[index];
            idList.RemoveAt(index);
            idList.Insert(0, value);
            Console.WriteLine();
            getIndex = 0;
            foreach (int item in idList)
            {
                Console.WriteLine(" After Id List Value - {0} ,Index - {1} ", item.ToString(), getIndex);
                getIndex++;
            }
        }
