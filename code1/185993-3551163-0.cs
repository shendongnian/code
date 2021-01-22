    public class OuterSpace<TData, TAnalysis, TCache>
        where TData : OuterSpaceData
        where TAnalysis : OuterSpaceAnalysis
        where TCache : OuterSpaceCache
    {
        public virtual TData Data { get; set; }
        public virtual TAnalysis Analysis { get; set; }
        public virtual TCache Cache { get; set; }
    }
    public class OuterSpaceData { }
    public class OuterSpaceAnalysis { }
    public class OuterSpaceCache { }
    
    public class Sun : OuterSpace<SunData, SunAnalysis, SunCache>
    {
        public override SunData Data { get; set; }
        public override SunAnalysis Analysis { get; set; }
        public override SunCache Cache { get; set; }
    }
    public class SunData : OuterSpaceData { }
    public class SunAnalysis : OuterSpaceAnalysis { }
    public class SunCache : OuterSpaceCache { }
