        static readonly
            Dictionary<VaryByCustomType, IOutputCacheVaryByCustom> cloneDictionary
            = new Dictionary<VaryByCustomType, IOutputCacheVaryByCustom>
            {
                {VaryByCustomType.IsAuthenticated, new ObjectType1{}},
                {VaryByCustomType.Roles, new ObjectType2{}},
            };
            
