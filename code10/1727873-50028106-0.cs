    class DataItem {
        public string Value { get; set; }
    }
    
    // loop version
    private IEnumerable<string> GetItems(DataItem[] data, Func<string, bool> criteriaFunction) {
        var ret = new List<string>();
        // Not deferred; runs all at once
        for (int i = 0; i < data.Length; i++) {
            if (criteriaFunction(data[i].Value)) {
                ret.Add(data[i].Value);
            }
        }
        return ret;
    }
    // linq version
    var result = data.Select(c => c.Value).Where(criteriaFunction).ToList();
