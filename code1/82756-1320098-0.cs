    using System.Data;
    using System.Data.SqlClient;
    
    using(SqlConnection connection = new SqlConnection("")){
    	SqlCommand command = new SqlCommand(@"
    insert into
    	tblFoo (
    		col1,
    		col2
    	) values (
    		@val1,
    		@val2
    	)",
    	connection
    	);
    
    	SqlParameter param = new SqlParameter("@val1", SqlDbType.NVarChar);
    	param.Value = "hello";
    
    	command.Parameters.Add(param);
    	
    	param = new SqlParameter("@val2", SqlDbType.NVarChar);
    	param.Value = "there";
    	
    	command.Parameters.Add(param);
    
    	command.ExecuteNonQuery();
    	connection.Close();
    }
