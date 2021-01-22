    public class BigPerformance 
    {
        //constructors 'n stuff
        public static decimal DEFAULT;
        public decimal Value {get; private set;}
        public void reset() {
            Value = BigPerformance.DEFAULT;
        }
    }
    public class Performance
    {
        //constructors 'n stuff
        private BigPerformance BigPerf {get; set};
        public reset() {
            BigPerf.reset();
        }
    }
    public class Category
    {
        // constructors 'n stuff
        public Performance Perf {get; private set;}
        public resetPerformance() {
            Perf.reset();
        }
    }
