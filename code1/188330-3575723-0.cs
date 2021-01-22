        public static IEnumerable<T> AdNauseam<T>(this IEnumerable<T> i_list)
        {
            using(var etor = i_list.GetEnumerator())
            {
                while(true)
                {
                    while(etor.MoveNext())
                    {
                        yield return etor.Current;
                    }
                    etor.Reset();
                }
            }
        }
