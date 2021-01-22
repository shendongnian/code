    public static class ExcelHelper
    {
        private static Dictionary<UInt16, String> l_DictionaryOfColumns;
        public static ExcelHelper() {
            l_DictionaryOfColumns = new Dictionary<ushort, string>(256);
        }
        public static String GetExcelColumnName(UInt16 l_Column)
        {
            UInt16 l_ColumnCopy = l_Column;
            String l_Chars = "0ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            String l_rVal = "";
            UInt16 l_Char;
            if (l_DictionaryOfColumns.ContainsKey(l_Column) == true)
            {
                l_rVal = l_DictionaryOfColumns[l_Column];
            }
            else
            {
                while (l_ColumnCopy > 26)
                {
                    l_Char = l_ColumnCopy % 26;
                    if (l_Char == 0)
                        l_Char = 26;
                    l_ColumnCopy = (l_ColumnCopy - l_Char) / 26;
                    l_rVal = l_Chars[l_Char] + l_rVal;
                }
                if (l_ColumnCopy != 0)
                    l_rVal = l_Chars[l_ColumnCopy] + l_rVal;
                l_DictionaryOfColumns.ContainsKey(l_Column) = l_rVal;
            }
            return l_rVal;
        }
    }
