    string printOutput = "";
    using (var conn = new SqlConnection(...))
    {
        // handle this event to receive the print output
        conn.InfoMessage += (object obj, SqlInfoMessageEventArgs e) => {
            printOutput += e.Message;
        };
    
        // execute command, etc.
    }
    
    Console.Write(printOutput);
