    var list = new List<Test>();
            for (int i = 1; i < 20; i++)
            {
                list.Add(new Test($"descrition {i}"));
            }
            var listDynamic = new List<object>();
            foreach (var item in list)
            {
                var properties = item.GetType().GetProperties();
                object expando = new ExpandoObject();
                var p = expando as IDictionary<string, object>;
                foreach (var property in properties)
                {
                    var value = item.GetType().GetProperty(property.Name).GetValue(item, null);
                    p[property.Name] = value;
                }
                listDynamic.Add(p);
            }
