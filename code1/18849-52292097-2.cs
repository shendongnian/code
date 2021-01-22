    using System.Collections.Generic;
    using System.Linq;
    
    public static class DictionaryExtensions
    {
        public enum MergeKind { SkipDuplicates, OverwriteDuplicates }
        public static void Merge<K, V>(this IDictionary<K, V> target, IDictionary<K, V> source, MergeKind kind = MergeKind.SkipDuplicates) =>
            source.ToList().ForEach(_ => { if (kind == MergeKind.OverwriteDuplicates || !target.ContainsKey(_.Key)) target[_.Key] = _.Value; });
    }
