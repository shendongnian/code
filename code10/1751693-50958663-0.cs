    class SomeType { }
    class BinaryTree
    {
        public SomeType root = null;
        public void Add(SomeType something)
        {
            Insert(ref root, something);
        }
        private void Insert(ref SomeType current, SomeType newItem)
        {
            if (current == null)
                current = newItem;
        }
    }
