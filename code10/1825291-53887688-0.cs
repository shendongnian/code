    public class Tools
    {
        public static void saveToExcelTables<T>(List<T> obj, string tableType)
        {
            if (tableType == "A")
            {
                List<A> A_List = obj as List<A>;
            }
            if (tableType == "B")
            {
                List<B> B_List = obj as List<B>;
            }
        }
    }
