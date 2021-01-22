        static void Save<T>(T item)
            where T : class, IPublicObject
        {
            using (DataContext ctx = GetDataContext())
            {
                Table<T> table = ctx.GetTable<T>();
                // for insert...
                table.InsertOnSubmit(item);
                // for update...
                table.Attach(item, true);
                // for delete...
                table.DeleteOnSubmit(item);
                ctx.SubmitChanges();
            }
        }
