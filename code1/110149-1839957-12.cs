        /// <summary>
        /// Finds all implemented IEnumerables of the given Type
        /// </summary>
        public static IQueryable<Type> FindIEnumerables(this Type seqType)
        {
            if (seqType == null || seqType == typeof(object) || seqType == typeof(string))
                return new Type[] { }.AsQueryable();
            if (seqType.IsArray || seqType == typeof(IEnumerable))
                return new Type[] { typeof(IEnumerable) }.AsQueryable();
            if (seqType.IsGenericType && seqType.GetGenericArguments().Length == 1 && seqType.GetGenericTypeDefinition() == typeof(IEnumerable<>))
            {
                return new Type[] { seqType, typeof(IEnumerable) }.AsQueryable();
            }
            var result = new List<Type>();
            foreach (var iface in (seqType.GetInterfaces() ?? new Type[] { }))
            {
                result.AddRange(FindIEnumerables(iface));
            }
            return FindIEnumerables(seqType.BaseType).Union(result);
        }
        /// <summary>
        /// Finds all element types provided by a specified sequence type.
        /// "Element types" are T for IEnumerable&lt;T&gt; and object for IEnumerable.
        /// </summary>
        public static IQueryable<Type> FindElementTypes(this Type seqType)
        {
            return seqType.FindIEnumerables().Select(t => t.IsGenericType ? t.GetGenericArguments().Single() : typeof(object));
        }
