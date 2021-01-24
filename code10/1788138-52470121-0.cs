     static void Main(string[] args)
            {
               string fileName = System.IO.Path.Combine(@"C:\Users\Amen\Downloads", "ADMQH20X.DBC"); 
               string connectionString = $"Provider=VFPOLEDB;Data Source={fileName}";
               DataTable tbl = new DataTable(); 
               using(OleDbConnection con = new OleDbConnection(connectionString))
               using(OleDbCommand cmd = new OleDbCommand("select * from myTable", con))
               {
                  con.Open();
                  tbl.Load(cmd.ExecuteReader());
               }
    
               // do Something with datatable
            }
