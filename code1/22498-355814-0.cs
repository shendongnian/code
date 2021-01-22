    internal class BaseFinder
    {
        public static Type FindBase(params Type[] types)
        {
            if (types == null)
                return null;
    
            if (types.Length == 0)
                return null;
    
            Dictionary<Type, IList<Type>> baseTypeMap = new Dictionary<Type,IList<Type>>();
    
            // get all the base types and note the one with the longest base tree
            int maxBaseCount = 0;
            Type typeWithLongestBaseTree = null;
            foreach (Type type in types)
            {
                IList<Type> baseTypes = GetBaseTree(type);
                if (baseTypes.Count > maxBaseCount)
                {
                    typeWithLongestBaseTree = type;
                    maxBaseCount = baseTypes.Count;
                }
                baseTypeMap.Add(type, baseTypes);
            }
    
            // walk down the tree until we get to a common base type
            IList<Type> longestBaseTree = baseTypeMap[typeWithLongestBaseTree];
            for (int baseIndex = 0; baseIndex < longestBaseTree.Count;baseIndex++)
            {
                int commonBaseCount = 0;
                foreach (Type type in types)
                {
                    IList<Type> baseTypes = baseTypeMap[type];
                    if (!baseTypes.Contains(longestBaseTree[baseIndex]))
                        break;
                    commonBaseCount++;
                }
                if (commonBaseCount == types.Length)
                    return longestBaseTree[baseIndex];
            }
            return null;
        }
    
        private static IList<Type> GetBaseTree(Type type)
        {
            List<Type> result = new List<Type>();
            Type baseType = type.BaseType;
            do
            {
                result.Add(baseType);
                baseType = baseType.BaseType;
            } while (baseType != typeof(object));
            return result;
        }
    }
