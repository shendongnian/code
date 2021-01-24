	public class SearchHelper
	{
		//why does this need to return the model at all? the model isn't altered 
        //and would already be in scope for whatever is calling this method
		public static void GetSearchResults(SearchModel model)
		{
			List<ResultModel> results = new List<ResultModel>();
			try
			{
				using (SqlConnection conn = new SqlConnection("connection string"))
				{
					conn.Open();
					using (SqlCommand cmd = AdoBase.GetSqlCommand(model.SqlCommandName, conn))
					{
						//this will mutate the object, so you don't need a return type. I'd suggest refactoring this further.
						model.BuildSqlCommand(cmd);
						using (SqlDataReader reader = cmd.ExecuteReader())
						{
							//your code sample wasn't returning this, but maybe you intended to?
							BuildResultSet(reader);
						}
					}
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		private static IEnumerable<ResultModel> BuildResultSet(SqlDataReader reader)
		{
			var results = new List<ResultModel>();
			if (!reader.HasRows) { return results; }
			while (reader.Read())
			{
				ResultModel result = new ResultModel();
				//	...the result composition would need to be refactored in a similar way as well
				results.Add(result);
			}
			return results;
		}
	}
    public abstract class SearchModel
    {
    	public string SqlCommandName { get; private set; }
    
    	private SearchModel() { }
    
    	protected SearchModel(string sqlCommandName)
    	{
    		SqlCommandName = sqlCommandName;
    	}
    
    	public abstract void BuildSqlCommand(SqlCommand command);
    }
	public class UserSearchModel : SearchModel
	{
		public string Name { get; set; }
		public string Username { get; set; }
		public UserSearchModel() : base("GeneralUserSearch")
		{
		}
		//warning...this mutates the input parameter
		public override void BuildSqlCommand(SqlCommand command)
		{
			if (!string.IsNullOrWhiteSpace(Name))
			{
				command.Parameters.AddWithValue(nameof(Name), Name);
			}
			if (!string.IsNullOrWhiteSpace(Username))
			{
				command.Parameters.AddWithValue(nameof(Username), Username);
			}
		}
	}
