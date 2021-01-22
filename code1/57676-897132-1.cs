        Dictionary<string, string> getValidIds(
                IDictionary<string, string> salesPersons,
                IEnumerable<string> ids) {
            var result = new Dictionary<string, string>();
            string value;
            foreach (string key in ids) {
                if (salesPersons.TryGetValue(key, out value)) {
                    result.Add(key, value);
                }
            }
            return result;
        }
