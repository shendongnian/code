    using (BulkOperation copy = new BulkOperation(conn2))
    {
    	copy.DestinationTableName = destinationTable;
    	copy.BatchSize = 1000;
    	copy.BatchTimeout = 240;
    	copy.BulkMerge(dt);
    
    	MessageBox.Show("Data successfully transfered to Central Database", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
