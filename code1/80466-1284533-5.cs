//Simulates data coming from a database or another data source
DataTable origin = new DataTable(); 
DataColumnCollection columns = origin.Columns; 
columns.Add("Id", typeof(int)); 
columns.Add("Name", typeof(string)); 
origin.Rows.Add(55, "Foo"); 
origin.Rows.Add(14, "Bar"); 
IDataReader reader = origin.CreateDataReader();
DataTable table = new DataTable(); 
//Sets up your target table to include a new column for displaying row numbers
//These are the three lines that make it all happen.
DataColumn col = table.Columns.Add("RowNumber", typeof(int)); 
col.AutoIncrementSeed = 1; 
col.AutoIncrement = true; 
//Simulates loading data from the database
table.Load(reader); 
// Examine table through the debugger. Is will have the contents of "origin" with the column "RowNumber" prepended
