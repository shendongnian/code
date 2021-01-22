    public class OuterSpace<TCacheType> where TCacheType : OuterSpaceCache {
        public virtual OuterSpaceData Data {get; set;}
        public virtual OuterSpaceAnalysis Analysis {get; set;}
        public virtual TCacheType Cache {get; set;}
    
    
        public class OuterSpaceData {
            //Lots of basic Data Extraction routines eg
            public virtual GetData();
        }
        public class OuterSpaceAnalysis {
            //Lots of Generic Analysis on Data routines eg
            public virtual GetMean();
        }
        public class OuterSpaceCache {
            //Lots of Caches of Past Analysis Results:
            public Dictionary<AnalysisType, List<Result>> ResultCache;
        }
    }
    
    public class Sun : OuterSpace<SunCache> {
        public override SunData Data {get; set;}
        public override SunAnalysis Analysis {get; set;}
    
        public SunData : OuterSpaceData {
            //Routines to specific get data from the sun eg
            public override GetData();
        }
    
        public SunAnalysis : OuterSpaceAnalysis {
            //Routines specific to analyse the sun: eg
            public double ReadTemperature();
        }
        public SunCache : OuterSpaceCache {
            //Any data cache's specific to Sun's Analysis
            public Dictionary<AnalysisType, List<Result>> TempCache;
        }
    }
