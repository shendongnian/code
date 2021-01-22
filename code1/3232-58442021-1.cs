        public static IEnumerable<int> CreateCollectionWithYield()
        {
            yield return 10;
            for (int i = 0; i < 3; i++) 
            {
                yield return i;
            }
    
            yield return 20;
        }
