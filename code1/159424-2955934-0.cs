    using (var db = GetDatabase()) {
        // Retrieves array of keys
        var keys = db.GetRecords(mySelection); 
        for(int i = 0; i < keys.Length; i++) {
           var record = db.GetRecord(keys[i]);
           record.DoWork();
           keys[i] = null; // GC can dispose of key now
           // The record had gone out of scope automatically, 
           // and does not need any special treatment
        }
    } // end using => db.Dispose is called
