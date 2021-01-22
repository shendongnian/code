    public class Project
    {
        public static IEnumerable<Tdest> From<Tsource, Tdest>
            (IEnumerable<Tsource> source, Func<Tsource, Tdest> projection)
        {
            foreach (Tsource item in source)
                yield return projection(item);
        }
    }
