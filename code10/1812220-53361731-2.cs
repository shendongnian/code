    class LinkListGen<T> where T : IComparable
    {
        private LinkGen<T> list;
        public LinkListGen()
        {
        }
        public string DisplayList()
        {
            Console.WriteLine(test);
            foreach (string word in words)
            {
                Console.Write(word + " ");
            }
            Console.WriteLine();
            Console.WriteLine();
        }
        public void AddItem(T item)
        {
            list = new LinkGen<T>(item);
        }
        public int NumberOfItems()
        {
            //Do Something
        }
        public int Count { get; }
        public bool IsPresentItem(T item)
        {
            Link temp = list;
            bool result = false;
            while (temp != null)
            {
                if (temp.Data == item)
                {
                    result = true;
                    break;
                }
                else
                {
                    temp = temp.Next;
                }
            }
            return result;
        }
    }
