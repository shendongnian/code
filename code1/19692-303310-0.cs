    DataRow record = GetSomeRecord();
    int? someNumber = record[15] as int?
    Guid? someUID = record["MyPrimaryKey"] as Guid?;
    string someText = GetSomeText();
    record["Description"] = someText.ToDbString();
    // ........
    public static class StringExtensionHelper {
        public static object ToDbString( this string text ) {
             object ret = null != text ? text : DBNull.Value
             return ret;
        }
    }
