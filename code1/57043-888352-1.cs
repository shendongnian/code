      public static void Main()
      {
            DataTable table = new DataTable();
            table.Columns.Add("Name");
            table.Columns.Add("Age");
            table.Rows.Add("John Doe", "45");
            table.Rows.Add("Jane Doe", "35");
            table.Rows.Add("Jack Doe", "27");
            var bytes = Encoding.GetEncoding("iso-8859-1").GetBytes(table.ToCSV());
            MemoryStream stream = new MemoryStream(bytes);
    
            StreamReader reader = new StreamReader(stream);
            Console.WriteLine(reader.ReadToEnd());
      }
