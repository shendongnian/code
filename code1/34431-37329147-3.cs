    public class StringListCustomType : IOracleCustomType, INullable
    {
        public const string Name = "MYSCHEMA.VARCHAR2_TAB_T";
        [OracleArrayMapping()]
        public string[] Array;
        #region IOracleCustomType
        public OracleUdtStatus[] StatusArray { get; set; }
        public void ToCustomObject(OracleConnection con, IntPtr pUdt)
        {
            object objectStatusArray = null;
            Array = (string[])OracleUdt.GetValue(con, pUdt, 0, out objectStatusArray);
            StatusArray = (OracleUdtStatus[])objectStatusArray;
        }
        public void FromCustomObject(OracleConnection con, IntPtr pUdt)
        {
            OracleUdt.SetValue(con, pUdt, 0, Array, StatusArray);
        }
        #endregion
        #region INullable
        public bool IsNull { get; set; }
        public static StringListCustomType Null
        {
            get
            {
                StringListCustomType obj = new StringListCustomType();
                obj.IsNull = true;
                return obj;
            }
        }
        #endregion
    }
