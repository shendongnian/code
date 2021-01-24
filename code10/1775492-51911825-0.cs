    var connString = "Host=x.x.x.x;Port=5432;Username=postgres;Password=password;Database=database";
    
    using (var conn = new Npgsql.NpgsqlConnection(connString))
    {
        conn.Open();
    
        int ctr = 0;
    
    	@Info.Trace("Pushed Data: PostGre A " + ctr.ToString());
    	
    	using (var cmd = new Npgsql.NpgsqlCommand())
    	{
    		cmd.Connection = conn;
    		
    		var par_1 = cmd.Parameters.Add("@p1", /*< appropriate datatype here >*/);
    		var par_2 = cmd.Parameters.Add("@p2", /*< appropriate datatype here >*/);
    		
    		while(@tag.TerminateTimeScaleLoop == 100)
    		{
    			cmd.CommandText = "INSERT INTO TORQX VALUES (@p1,@p2)";
    			par_1.Value = System.DateTime.Now.ToUniversalTime());
    			par_2.Value = @Tag.RigData.Time.TORQX;
    			
    			cmd.ExecuteNonQuery();
    
    			cmd.CommandText = "INSERT INTO BLKPOS VALUES (@p1,@p2)";
    			
    			par_1.Value = System.DateTime.Now.ToUniversalTime());
    			par_2.Value = @Tag.RigData.Time.BLKPOS;
    			
    			cmd.ExecuteNonQuery();
    			
    			ctr = ctr + 1;
    		}
        }
    }
    @Info.Trace("Pushed Data: PostGre A Terminated");
