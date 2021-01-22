        IEnumerable<T> parser<T>(string csv, Func<string, T> newFunc)
        {
            List<T> items = new List<T>();
            string[] ary = csv.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string val in ary)
            {
                try
                {
                    items.Add(newFunc(val));
                }
                catch
                {
                    // empty catch alert
                }
            }
            return items;
        }
