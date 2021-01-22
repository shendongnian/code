     public class ContextHelper<T>  : IContextHelper<T>
        {
            //Instantiate your own EntityFrameWork DB context here,
            //Ive called the my EntityFramework Namespace 'EF' and the context is named 'Reporting'
            private EF.DataContext DbContext = new EF.DataContext(); 
            public bool Insert<T>(T row) where T : class
            {
                try
                {
                    DbContext.Set<T>().Add(row);
                    DbContext.SaveChanges();
                    return true;
                }
                catch(Exception ex)
                {
                    return false;
                }
            }
            public bool Update<T>(T row) where T : class
            {
                try
                {
                    DbContext.Set<T>().AddOrUpdate(row);
                    DbContext.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
            public bool Delete<T>(T row) where T : class
            {
               return Update(row); //Pass an entity with IsActive = false and call update method
            }
            public bool AddRows<T>(T[] rows) where T : class
            {
                try
                {
                    DbContext.Set<T>().AddOrUpdate(rows);
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
