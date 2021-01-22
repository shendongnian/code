    [SQLiteFunction(Name = "REGEXP", Arguments = 2, FuncType = FunctionType.Scalar)]
    class MyRegEx : SQLiteFunction
    {
       public override object Invoke(object[] args)
       {
          return System.Text.RegularExpressions.Regex.IsMatch(Convert.ToString(args[1]),Convert.ToString(args[0]));
       }
    }
    // example SQL:  SELECT * FROM Foo WHERE Foo.Name REGEXP '$bar'
