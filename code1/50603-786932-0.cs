        public static T FindOrCreate<T>(this Table<T> table, Func<T, bool> find, Action<T> create) where T : new()
        {
            T val = table.FirstOrDefault(find);
            if (val == null)
            {
                val = new T();
                create(val);
                table.InsertOnSubmit(val);
            }
            return val;
        }
