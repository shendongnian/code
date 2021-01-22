LINQ version using the IEnumerable&lt;T&gt; extension methods:
        private static IDictionary&lt;ILanguage, IDictionary&lt;string, string&gt;&gt; ConvertKeysToLowerCase(
            IDictionary&lt;ILanguage, IDictionary&lt;string, string&gt;&gt; dictionaries)
        {
            return dictionaries.ToDictionary(
                x => x.Key, v => CloneWithComparer(v.Value, StringComparer.OrdinalIgnoreCase));
        }
        static IDictionary&lt;K, V&gt; CloneWithComparer&lt;K,V&gt;(IDictionary&lt;K, V&gt; original, IEqualityComparer&lt;K&gt; comparer)
        {
            return original.ToDictionary(x => x.Key, x => x.Value, comparer);
        }
