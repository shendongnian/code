        public class OutputCacheVaryByIsAuthenticated: IOutputCacheVaryByCustom
        {
            public IOutputCacheVaryByCustom NewObject() 
            {
                return new OutputCacheVaryByIsAuthenticated(); 
            }
        }
