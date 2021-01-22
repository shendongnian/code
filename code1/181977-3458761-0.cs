      using (ODBCConnection c = new ODBCConnection(ConnectionString))
      {
        c.Command.CommandType = CommandType.Text;
        // make a call
      }
