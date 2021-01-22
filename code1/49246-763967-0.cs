        static void Main(string[] args)
        {
            BindingList<string> list = new BindingList<string>();
            list.Add("Hello");
            list.Add("World");
            list.Add("Test");
            MoveLastToFirst(list);
            Swap(list, 1, 2);
            foreach (string s in list)
                Console.WriteLine(s); // Prints Test World Hello
        }
        private static void MoveLastToFirst<T>(BindingList<T> list)
        {
            int cnt = list.Count;
            T temp = list[cnt - 1];
            list.RemoveAt(cnt - 1);
            list.Insert(0, temp);
        }
        private static void Swap<T>(BindingList<T> list, int first, int second)
        {
            T temp = list[first];
            list[first] = list[second];
            list[second] = temp;
        }
