            class ClassA
            {
                // Will work
                public string Name { get; set; }
                // Will not work
                public string Name;
            }
    
            public static async Task Main(string[] args)
            {
                IQueryable<ClassA> query = ...
                search(query, Tuple.Create(nameof(ClassA.Name), "myName"));
            }
    
            public static IQueryable<T> search<T>(
                IQueryable<T> query,
                params Tuple<string, string>[] parameters)
                where T : class
            {
                foreach(var criteria in parameters) {
                    var property = typeof(T).GetProperty(criteria.Item1);
                    if (property == null) continue;
                    // you also need to verify the property was retrievable from the instance.
                    query = query.Where(item => property.GetValue(item) != null)
                        .Where(item => property.GetValue(item).ToString().Contains(criteria.Item2));
                }
           
                return query;
            }
