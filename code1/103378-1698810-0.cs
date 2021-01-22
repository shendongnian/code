    public static class IDictionaryExtension {
        public static TValue GetValue<TKey, TValue>(this IDictionary<TKey, TValue> dict, TKey key, TValue default) {
            TValue result;
            return dict.TryGetValue(key, out result) ? result : dflt;
        }
    }
    ...
    lvwRetailStores.DataSource = list.OrderByDescending(r => r.GetValue("RS_Partner Type", "").ToString())
                                     .ThenBy(r => r.GetValue("RS_Title","").ToString());
