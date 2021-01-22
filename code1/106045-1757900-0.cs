    string selectSql = "select * From X Where Y;";		
    using(var conn = OpenNewConnection()){
    	StringBuilder updateBuilder = new StringBuilder();
    	
    	using(var cmd = new SQLiteCommand(selectSql, conn))
    	using(var ranges = cmd.ExecuteReader()) {
		    while(MemberVariable > 0 && ranges.Read()) {
			    updateBuilder.Append("Update X Set Z = 'foo' Where Y;");
		    }
	    }
    
    	using(var trans = conn.BeginTransaction())
    	using(var updateCmd = new SQLiteCommand(updateBuilder.ToString(), conn, trans) {
		    cmd.ExecuteNonQuery();
		    trans.Commit();
	    }
    }	
