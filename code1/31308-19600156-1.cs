        public SerializeableKeyValue<int, string>[] SearchCategoriesSerializable
        {
            get
            {
                var list = new List<SerializeableKeyValue<int, string>>();
                if (SearchCategories != null)
                {
                    list.AddRange(SearchCategories.Keys.Select(key => new SerializeableKeyValue<int, string>() {Key = key, Value = SearchCategories[key]}));
                }
                return list.ToArray();
            }
            set
            {
                SearchCategories = new Dictionary<int, string>();
                foreach (var item in value)
                {
                    SearchCategories.Add( item.Key, item.Value );
                }
            }
        }
