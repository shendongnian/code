    using System.Collections.Generic;
    using System.Linq;
    
    public static partial class Extensions
    {
        public static void Merge<K, V>(this IDictionary<K, V> target, IDictionary<K, V> source, bool overwrite = false)
        {
            source.ToList().ForEach(_ => {
                if ((!target.ContainsKey(_.Key)) || overwrite)
                    target[_.Key] = _.Value;
            });
        }
    }
