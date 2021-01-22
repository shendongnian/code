    using System.Data;
    
    class Program {
      static DataTable dtPosts = new DataTable();
      static void Main(string[] args) {
        //some work here to fill the table, etc.
        //select distinct rows, and only two fields from those rows...
        var rows = (from p in dtPosts.AsEnumerable()
                select new
                {
                    Title = p.Field<string>("Title"),
                    Body = p.Field<string>("Body")
                }).Distinct();
    
        Console.WriteLine("Select distinct count = {0}", rows.Count());
        Console.ReadLine();
      }
    }
