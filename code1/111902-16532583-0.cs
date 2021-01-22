    SqlConnection conn = new SqlConnection(ConnectionString);
    //anonymous function to dump print statements to output console
    conn.InfoMessage += (object obj, SqlInfoMessageEventArgs e)=>{
        			e.Message.Dump();
        		};
