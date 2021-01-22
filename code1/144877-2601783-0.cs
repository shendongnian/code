    public static class SwitchUtilities
    {
        public static IEnumerable<T> PairSwitch<T>(this IEnumerable<T> source)
        {
            T lastItem = default(T);
            bool odd = true;
        
            foreach(T value in source)
            {
                if(odd)
                {
                    lastItem = value;
                    odd = false;
                }
                else
                {
                    yield return value;
                    yield return lastItem;
        
                    odd = true;
                }        
            }
        }
    }
