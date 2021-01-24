		//the main class to update/delete sql batches without using DataSet/DataTable.
		public class SqlBatchUpdate
			{
				string ConnectionString { get; set; }
				public SqlBatchUpdate(string connstring)
				{
					ConnectionString = connstring;
				}
				public int RunSql(string sql)
				{
					using (SqlConnection con = new SqlConnection(ConnectionString))
					using (SqlCommand cmd = new SqlCommand(sql, con))
					{
						cmd.CommandType = CommandType.Text;
						con.Open();
						int rowsAffected = cmd.ExecuteNonQuery();
						return rowsAffected;
					}
				}
			}
		//------------------------
        // using the class to run a predefined patches
	     public class SqlBatchUpdateDemo
			{       
			   private string connstring = "myconnstring";
			   
			   //run batches in sequence
			public void RunBatchesInSequence()
			{
				var sqlBatchUpdate = new SqlBatchUpdate(connstring);
			
				//batch1
				var sql1 = @"update mytable set value2 =1234 where id =4  and Value1>0;";
				var nrows = sqlBatchUpdate.RunSql(sql1);
				Console.WriteLine("batch1: {0}", nrows);
				
				//batch2
				var sql2 = @"update mytable set value3 =1234 where  	id =4 	and Value1 =0";
				  nrows = sqlBatchUpdate.RunSql(sql2);
				Console.WriteLine("batch2: {0}", nrows);
				
				//batch3
				var sql3 = @"delete from  mytable where id =5;";
				  nrows = sqlBatchUpdate.RunSql(sql3);
				Console.WriteLine("batch3: {0}", nrows);
			}
				// Alternative: you can run all batches as one 
					public void RunAllBatches()
					{
						var sqlBatchUpdate = new SqlBatchUpdate(connstring );
						StringBuilder sb = new StringBuilder();
						var sql1 = @"update mytable set value2 =1234 where id =4  and Value1>0;";
						sb.AppendLine(sql1);
						//batch2
						var  sql2 = @"update mytable set value3 =1234 where  	id =4 	and Value1 =0";
						sb.AppendLine(sql2);
					   
						//batch3
					   var sql3 = @"delete from  mytable where 	id =5;";
						sb.AppendLine(sql3);
						//run all batches
						var   nrows = c.RunSql(sb.ToString());
						Console.WriteLine("all patches: {0}", nrows);
					}
					
				
			}
