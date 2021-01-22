    // Need to read the row in, usually in a while ( opReader.Read ) {} loop...
    opReader.Read();
    // Convert current row into a dictionary
    Dictionary<string, object> dict = new Dictionary<string, object>();
    for( int lp = 0 ; lp < opReader.FieldCount ; lp++ ) {
        dict.Add(opReader.GetName(lp), opReader.GetValue(lp));
    }
