        public class ObjectType1 : IOutputCacheVaryByCustom
        {
            public IOutputCacheVaryByCustom NewObject() 
            {
                return new ObjectType1(); 
            }
        }
