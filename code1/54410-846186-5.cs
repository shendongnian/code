        		public void Update<T>(string prefix, IParameter<T> parameters, T entity)
			where T : class, IEntity<T>
		{
			using (var connection = this.Connection())
			{
				using (var command = new SqlCommand(string.Format("dbo.{0}_Update", prefix), connection))
				{
					command.CommandType = CommandType.StoredProcedure;
					parameters.Populate(command.Parameters, entity);
					connection.Open();
					command.ExecuteNonQuery();
					connection.Close();
				}
			}
		}
