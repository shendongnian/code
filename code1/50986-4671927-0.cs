        private static Type ResolveType(String typeName)
        {
            Type t = Type.GetType(typeName);
            if (t == null)
                return null;
            Type u = Nullable.GetUnderlyingType(t);
            if (u != null) {
                t = u;
            }
            return t;
        }
