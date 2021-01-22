    using System.
    using System.Data;
    class Program
    {
        static void Main(string[] args)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("test", typeof (char));
            dt.Columns["test"].AllowDBNull = true;
            DataRow dr = dt.Rows.Add();
            char? test;
            try
            {
                test = (char?)dr["test"];
            }
            catch (InvalidCastException)
            {
                Console.WriteLine("Simply casting to a nullable type doesn't work.");
            }
            test  = dr.Field<char?>("test");
            if (test == null)
            {
                Console.WriteLine("The Field extension method in .NET 3.5 converts System.DBNull to null.");                
            }
            test = (dr["test"] is DBNull) ? null : (char?) dr["test"];
            if (test == null)
            {
                Console.WriteLine("Before .NET 3.5, you have to check the type of the column's value.");
            }
            test = (dr["test"] == DBNull.Value) ? null : (char?) dr["test"];
            if (test == null)
            {
                Console.WriteLine("Comparing the field's value to DBNull.Value is very marginally faster, but takes a bit more code.");
            }
            // now let's put the data back
            try
            {
                dr["test"] = test;
            }
            catch (ArgumentException)
            {
                Console.WriteLine("You can't set nullable columns to null.");
            }
            dr.SetField("test", test);
            if (dr["test"] is DBNull)
            {
                Console.WriteLine("Again, in .NET 3.5 extension methods make this relatively easy.");
            }
            dr["test"] = (object)test ?? DBNull.Value;
            if (dr["test"] is DBNull)
            {
                Console.WriteLine("Before .NET 3.5, you can use the null coalescing operator, but note the awful cast required.");
            }
            Console.ReadLine();
        }
    }
