    public interface IShimOne
    {
        void MethodOne();
    }
    public interface IShimTwo: IShimOne
    {
        void MethodTwo();
    }
    #if NETFULL
    class One: RealOne, IShimOne {}
    class Two: RealTwo, IShimTwo {}
    public static class ShimFactory
    {
        public static IShimOne CreateOne() { return new One(); }
        public static IShimTwo CreateTwo() { return new Two(); }
    }
