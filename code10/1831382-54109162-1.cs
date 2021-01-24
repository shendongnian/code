      using System.Data;
      ... 
      private static bool Compute(string formula, int x, int y, int z) {
        using (var table = new DataTable()) {
          // variables of type int
          table.Columns.Add("x").DataType = typeof(int);
          table.Columns.Add("y").DataType = typeof(int);
          table.Columns.Add("z").DataType = typeof(int);
          table.Columns.Add("result").Expression = formula;
          table.Rows.Add(x, y, z);
          return Convert.ToBoolean(table.Rows[0]["result"]);
        }
      }
      ...
      // Please, not the syntax difference 
      Console.Write(Compute("(x = 1 and y = 3) or z = 3", 1, 2, 3));
