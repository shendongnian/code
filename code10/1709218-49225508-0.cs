		 public void RunQuery()
		 {
			using (var con = new SqlConnection(setting.ConnectionString))
			{
				try
				{
					//some codes
				}
				catch(SqlException ex)
				{
				//test for timeout
					if (ex.Number == -2) {
					Console.WriteLine ("Timeout occurred");
					// log ex details for more inspection
					}
				}
			   
			}
		}
