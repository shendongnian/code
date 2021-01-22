    using System.Linq;
    namespace Sample.Extensions
    {
        public static class ListExtensions
        {
            public static void RemoveHeader<T> (this List<T> list, List<T> header)
            {
                if (list.Take (header.Count).SequenceEqual (header))
                {
                    list.RemoveRange (0, header.Count);
                }
            }
        }
    }
