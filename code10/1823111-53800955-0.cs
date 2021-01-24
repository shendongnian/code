    Public object[] ItemArray {
        get {
            var values = new object[Columns.Count];
            for (int i = 0; i < values.Length; i++) {
                values[i] = Columns[i];
            }
        	return values;
        }
        set {
            for (int i = 0; i < values.Length; i++) {
                //Checks if the column is writable and value is valid
                Columns[i] = value[i];
            }
        }
    }
