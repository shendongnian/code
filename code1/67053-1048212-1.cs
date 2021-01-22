    private IEnumerator<object[]> GetEnumerator( DataTable dtRequired, DataTable dtResponse )
    {
        foreach( DataRow row in dtRequired.Rows )
        {
            // use the columns of the primary key below
            if( dtResult.Rows.Contains( new object[] { row[0], row[2], row[4] } ) )
                continue;
            else
                yield return row.ItemArray;
    
        }
    }
    
    private void GetComplement( DataTable dtRequired, DataTable dtResponse, out DataTable dtResult )
    {
        DataTable dtResult = dtRequired.Clone();
    
        foreach( object[] items in GetEnumerator( dtRequired, dtResponse ) )
        {
            dtResult.Rows.Add( items );
        }
    
        return;
    }
