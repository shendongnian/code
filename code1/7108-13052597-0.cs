    public static class EnumerableExtensions
    {
        static readonly RNGCryptoServiceProvider RngCryptoServiceProvider = new RNGCryptoServiceProvider();
        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> enumerable)
        {
            var randomIntegerBuffer = new byte[4];
            Func<int> rand = () =>
                                 {
                                     RngCryptoServiceProvider.GetBytes(randomIntegerBuffer);
                                     return BitConverter.ToInt32(randomIntegerBuffer, 0);
                                 };
            return from item in enumerable
                   let rec = new {item, rnd = rand()}
                   orderby rec.rnd
                   select rec.item;
        }
    }
