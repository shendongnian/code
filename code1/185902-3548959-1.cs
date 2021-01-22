    using(IDataReader reader = dataAccessLayer.GetData()) {
        if (! reader.IsClosed) {
            // Send writes to the client immediately
            // reader.Read advances the reader to the next record in the 
            // result set and discards the current record
            while (reader.Read()) {
                // Do something with the record - this just writes the first 
                // column to the response stream.
                Response.Write(reader[0]);
                // Send the content to the client immediately, even if the content
                // is buffered. The only data in memory at any given time is the
                // row you're working on.
                Response.Flush();
            }
        }
    }
