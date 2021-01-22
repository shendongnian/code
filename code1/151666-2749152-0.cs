    using (var writer = new StreamWriter(yourPath)) {
        for (int i = 0; i < yourTable.Rows.Count; i++) {
            DataRow row = yourTable.Rows[i];
            
            string[] textCells = row.ItemArray
                .Select(c => "\"" + c.ToString() + "\"") // pick some qualifier
                .ToArray();
        
            writer.WriteLine(string.Join(",", textCells));
        }
    }
