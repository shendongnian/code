    public async Task<ViewDataResult> IIS_File_Log_DataView_Get(int siteId, DateTime? dateTimeFrom, DateTime? dateTimeTo,
        string searchText,
        int httpStatus,
        string csHost,
        string csUserName,
        string sortColumn, Helpers.TableSortDirection sortDirection,
        int rowsPerPage, int pageNumber)
    {
        // get site SP name
        var site = await this.FtpSites.FindAsync(siteId);
    
        // set an empty return list at a minimum
        var t = new DataTable();
        var result = new ViewDataResult();
    
        // set the skip value from the current page number and rows per page
        int skip = ((pageNumber - 1) * rowsPerPage) - 1;
    
        //  if -ve, set to zero
        if (skip < 0)
        {
            skip = 0;
        }
    
        var sp = this.StoredProcedure_Get(site.LogDataViewStoredProcedure)
            .WithSqlParam("@DateTimeFrom", dateTimeFrom)
            .WithSqlParam("@DateTimeTo", dateTimeTo)
            .WithSqlParam("@SearchText", searchText ?? "")
            .WithSqlParam("@HttpStatus", httpStatus)
            .WithSqlParam("@CsHost", csHost)
            .WithSqlParam("@CsUserName", csUserName)
            .WithSqlParam("@SortColumn", sortColumn ?? "")
            .WithSqlParam("@SortDirection", sortDirection.ToString())
            .WithSqlParam("@Skip", skip)
            .WithSqlParam("@Take", rowsPerPage)
            // output param
            .WithSqlParam("@RowCount", 0, true);
    
        // open connection if not already open
        if (sp.Connection.State != ConnectionState.Open)
        {
            sp.Connection.Open();
        }
    
        // seconds
        sp.CommandTimeout = 120;
    
        // execute the SP
        using (var r = await sp.ExecuteReaderAsync())
        {
            if (r.HasRows)
            {
                // add columns
                for (int index = 0; index < r.FieldCount; index += 1)
                {
                    t.Columns.Add(r.GetName(index), r.GetFieldType(index));
                }
    
                while (await r.ReadAsync())
                {
                    var row = t.NewRow();
    
                    for (int index = 0; index < r.FieldCount; index += 1)
                    {
                        row[index] = r[index];
                    }
    
                    t.Rows.Add(row);
                }
            }
        }
    
        // get row count. By design, Microsoft implementation means this can't be read until reader is finished with
        if (sp.Parameters["@RowCount"].Value != null)
        {
            // set row count
            result.RowCount = (int)sp.Parameters["@RowCount"].Value;
        }
    
        // set data
        result.Data = t;
    
        result.CurrentPage = pageNumber;
        result.PageCount = pageNumber;
        result.PageCount = (result.RowCount / rowsPerPage) + (result.RowCount % rowsPerPage == 0 ? 0 : 1);
        result.RowsPerPage = rowsPerPage;
    
        // return
        return result;
    }
