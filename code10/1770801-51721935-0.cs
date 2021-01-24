    class MyCollection
    {
        public MyEnumerator GetEnumerator()
        {
            return new MyEnumerator();
        }
    }
    class MyEnumerator
    {
        int count = 0;
        public bool MoveNext()
        {
            count++;
            return count < 5;
        }
        public int Current => 42;
    }
