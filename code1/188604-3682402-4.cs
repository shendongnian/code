        static readonly
            Dictionary<VaryByCustomType, IOutputCacheVaryByCustom> cloneDictionary
            = new Dictionary<VaryByCustomType, IOutputCacheVaryByCustom>
            {
                {VaryByCustomType.IsAuthenticated, new OutputCacheVaryByIsAuthenticated{}},
                {VaryByCustomType.Roles, new OutputCacheVaryByRoles{}},
            };
            
