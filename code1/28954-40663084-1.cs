        public static bool IsExtension(this Type thisType, Type potentialSuperType)
        {
            //
            // protect ya neck
            //
            if (thisType == null || potentialSuperType == null || thisType == potentialSuperType) return false;
            
            //
            // don't need to traverse inheritance for interface extension, so check/do these first
            //
            if (potentialSuperType.IsInterface)
            {
                foreach (var interfaceType in thisType.GetInterfaces())
                {
                    var tempType = interfaceType.IsGenericType ? interfaceType.GetGenericTypeDefinition() : interfaceType;
                    if (tempType == potentialSuperType)
                    {
                        return true;
                    }
                }
            }
            //
            // do the concrete type checks, iterating up the inheritance chain, as in orignal
            //
            while (thisType != null && thisType != typeof(object))
            {
                var cur = thisType.IsGenericType ? thisType.GetGenericTypeDefinition() : thisType;
                if (potentialSuperType == cur)
                {
                    return true;
                }
                thisType = thisType.BaseType;
            }
            return false;
        }
