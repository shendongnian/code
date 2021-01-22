    class Program
    {
      static string[,] _users =
      {
        { "25", "Administrator" },
        { "29", "Robert" },
        { "55", "Amanda" },
      };
      static StringTemplate _documentTemplate = new StringTemplate(@"<DataTable source='$TableName$'><Rows>$Rows$</Rows></DataTable>");
      static StringTemplate _rowTemplate = new StringTemplate(@"<Row id='$0$' name='$1$' />");
      static void Main(string[] args)
      {
        _documentTemplate.SetParameter("TableName", "Users");
        _documentTemplate.SetParameter("Rows", GenerateRows);
        Console.WriteLine(_documentTemplate.GenerateString(4096));
        Console.ReadLine();
      }
      private static void GenerateRows(StreamWriter writer)
      {
        for (int i = 0; i <= _users.GetUpperBound(0); i++)
          _rowTemplate.GenerateString(writer, _users[i, 0], _users[i, 1]);
      }
    }
