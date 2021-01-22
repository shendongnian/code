        		public void Update<T>(string prefix, IParameter<T> parameters, T entity)
			where T : class, IEntity<T>
		{
			using (var connection = this.Connection())
			{
				using (var command = new SqlCommand("dbo.{0}_Update".Fmt(prefix), connection))
				{
					command.CommandType = CommandType.StoredProcedure;
					parameters.Populate(command.Parameters, entity);
					connection.Open();
					command.ExecuteNonQuery();
					connection.Close();
				}
			}
		}
