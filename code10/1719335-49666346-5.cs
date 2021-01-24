        public static IEnumerable<int> NonRepeating(this IEnumerable<int> source)
        {
            int previous =0;
            bool isAssigned=false;
            foreach (var item in source)
            {
                if (!isAssigned || item != previous)
                {
                    isAssigned = true;
                    previous = item;
                    yield return item;
                }
            }
        }
