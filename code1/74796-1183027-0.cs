    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    namespace MiscellaneousUtilities
    {
        public static class Enumerable
        {
            public static T[,] ToRow<T>(this IEnumerable<T> target)
            {
                var array = target.ToArray();
                var output = new T[1, array.Length];
                foreach (var i in System.Linq.Enumerable.Range(0, array.Length))
                {
                    output[0, i] = array[i];
                }
                return output;
            }
            public static T[,] ToColumn<T>(this IEnumerable<T> target)
            {
                var array = target.ToArray();
                var output = new T[array.Length, 1];
                foreach (var i in System.Linq.Enumerable.Range(0, array.Length))
                {
                    output[i, 0] = array[i];
                }
                return output;
            }
        }
    }
