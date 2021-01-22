    static class Algorithms
    {
        public static T Sum<P, T>(this P p, params T[] a)
            where P: INumericPolicy<T>
        {
            var r = p.Zero();
            foreach(var i in a)
            {
                r = p.Add(r, i);
            }
            return r;
        }
        ...
    }
