    class MyCollection
    {
        public IEnumerator<int> GetEnumerator()
        {
            for (int count = 0; count < 5; count++) { 
                yield return 42;
            }
        }
    }
