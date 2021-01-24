    class MyCollection
    {
        public IEnumerator<int> GetEnumerator()
        {
            for (int index = 1; index <= 5; index++) { 
                yield return index;
            }
        }
    }
