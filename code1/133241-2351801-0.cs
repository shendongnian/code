After having trouble to get it working with the IList<<span>T</span>> interface I solved it using the IList interface like [itowlson][1] proposed. It's a little bit ugly because of the _T method but it works well:
    object list = new List<int>();
    Type[] types = { list.GetType() };                
    MethodInfo openMethod = typeof(Extensions).GetMethod("ToDataTable", types);
    DataTable tbl = (DataTable)openMethod.Invoke(null, new object[] { list });
    public static class Extensions
    {
        private static DataTable ToDataTable(Array array) {...}
        private static DataTable ToDataTable(ArrayList list) {...}
        private static DataTable ToDataTable_T(IList list) {...}
        public static DataTable ToDataTable(this IList list)
        {
            if (list.GetType().IsArray)
            {
                // handle arrays - int[], double[,] etc.
                return ToDataTable((Array)list);
            }
            else if (list.GetType().IsGenericType)
            {
                // handle generic lists - List<T> etc.
                return ToDataTable_T(list);
            }
            else
            {
                // handle non generic lists - ArrayList etc.
                return ToDataTable((ArrayList)list);
            }            
        }
    }
