    class MyCollection
    {
        int count = 0;
        public IEnumerator<int> GetEnumerator()
        {
            while (count < 5)
            {
                count++;
                yield return 42;
            }
        }
    }
