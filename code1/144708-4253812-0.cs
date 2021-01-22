       public static SPListItem OptimizedAddItem(SPList list)
       {
           const string EmptyQuery = "0";
           SPQuery q = new SPQuery { Query = EmptyQuery };
           return list.GetItems(q).Add();
       }
