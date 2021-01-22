    namespace ExtensionMethods
    {
        public static class MyExtensions
        {
            public static bool Matches<T>(this List<T> list1, List<T> list2)
            {
                if (list1.Count != list2.Count) return false;
                for (var i = 0; i < list1.Count; i++)
                {
                    if (list1[i] != list2[i]) return false;
                }
                return true;
            }
        }   
    }
