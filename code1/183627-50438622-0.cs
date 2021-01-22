    public static int Count(this ICollectionView view)
        {
            var index = 0;
            foreach (var unused in view)
            {
                index++;
            }
            return index;
        }
