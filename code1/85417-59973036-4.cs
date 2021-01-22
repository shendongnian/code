        public static bool TryGetNameAlias(this Type t, out string alias)
        {
            string arrayBrackets = null;
            while (t.IsArray)
            {
                arrayBrackets += "[" + new string(',', t.GetArrayRank() - 1) + "]";
                t = t.GetElementType();
            }
            alias = TypeAliases[(int)Type.GetTypeCode(t)];
            if (alias == null || t.IsEnum)
                return false;
            alias += arrayBrackets;
            return true;
        }
    }
