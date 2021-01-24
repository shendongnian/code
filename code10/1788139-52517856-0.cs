    void Main()
    {
    	if (IntPtr.Size == 8)
    	{
    		Console.WriteLine("Sorry this is not going to work in 64 bits");
    	}
    	else
    	{
    		DataTable tbl=new DataTable();
    		using (OleDbConnection con = new OleDbConnection(@"Provider=VFPOLEDB;Data Source=c:\Temp"))
    		{
    			con.Open();
    			new OleDbCommand("create table myTest (id int, dummy c(10))",con).ExecuteNonQuery();
    			var cmd = new OleDbCommand(@"insert into myTest (id, dummy) values (?,?)",con);
    			cmd.Parameters.Add("id", OleDbType.Integer);
    			cmd.Parameters.Add("dum", OleDbType.VarChar,10);
    			
    			for (int i = 0; i < 10; i++)
    			{
    				cmd.Parameters["id"].Value = i + 1;
    				cmd.Parameters["dum"].Value = $"Dummy#{i+1}";
    				cmd.ExecuteNonQuery();
    			}
    			
    			tbl.Load(new OleDbCommand("select * from myTest",con).ExecuteReader());
    		}
    		foreach (DataRow row in tbl.Rows)
    		{
    			Console.WriteLine($"{(int)row["id"]} : {(string)row["Dummy"]}");
    		}
    	}
    	Console.ReadLine();
    }
