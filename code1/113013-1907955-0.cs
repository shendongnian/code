    namespace System.Data.Linq
    {
        public static class DataContextExtensions
        {
             public static (Table<T>,IQueryable, whatever) 
                MyExtensionMethod(this DataContext context, Args args)
             {
                //do your magic here
             }
        }
    }
