    using System.Linq;
    // (...)
    var dictionary = new Dictionary<string, object>();
    // (...)
    var read_only = dictionary.ToLookup(kv => kv.Key, kv => kv.Value);
