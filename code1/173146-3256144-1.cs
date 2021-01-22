    public interface IServerComponent
    {
        bool Add(int a, int b);
    }
    public static class ServerComponentExtensions
    {
        public static bool Add(this IServerComponent isc, int a, int b, int c)
        {
            return isc.Add(a, b) && isc.Add(b, c) && isc.Add(c, a);
        }
    }
