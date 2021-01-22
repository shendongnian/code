    using System.Data.SQLite;
    namespace War3Share.Client.DAL
    {
        [SQLiteFunction(Arguments = 1, FuncType = FunctionType.Scalar, Name = "String2Int")]
        class String2Int : SQLiteFunction
        {
            public override object Invoke(object[] args)
            {
                string s = args[0] as string;
                return int.Parse(s);
            }
        }
    }
