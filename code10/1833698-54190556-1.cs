    private async void btnSearch_Click(object sender, EventArgs e)
    {
        this.gridLog.DataSource = null;
        this.Cursor = Cursors.WaitCursor;
        if (this.btnSearch.Text.ToLower().Contains("load"))
        {
            this.btnSearch.Text = "Cancel";
            this.btnSearch.ForeColor = Color.White;
            this.btnSearch.BackColor = Color.Red;
            //get params to pass
            /* snip */
            this.cancellationTokenSource = new CancellationTokenSource();
            List<DocLog> list = await DocLog.FindForLocationAsync(docType, subType, days, currLocation.ID, cancellationTokenSource.Token);
            gridLog.DataSource = new BindingList<DocLog>( list );
                
            this.btnSearch.Text = "Load Data...";
            this.btnSearch.ForeColor = Color.Black;
            this.btnSearch.BackColor = Color.FromArgb(225, 225, 225);
        }
        else
        {
            CancelSearch();
            this.btnSearch.Text = "Load Data...";
            this.btnSearch.ForeColor = Color.Black;
            this.btnSearch.BackColor = Color.FromArgb(225, 225, 225);
        }
            
        this.Cursor = Cursors.Default;
    }
    private void CancelSearch()
    {
        this.cancellationTokenSource?.Cancel();
    }
    public async static Task<List<DocLog>> FindForLocationAsync(string DocType, string SubType, int? LastXDays, Guid LocationID, CancellationToken cancellationToken)
    {
        List<DocLog> dll = new List<DocLog>();
    
        using (SqlConnection sqlConnection = new SqlConnection(Helper.GetConnectionString()))
        using (SqlCommand sqlCommand = sqlConnection.CreateCommand())
        {
            await sqlConnection.OpenAsync(cancellationToken).ConfigureAwait(false);
            sqlCommand.CommandText = (LastXDays == null) ? "DocLogGetAllForLocation" : "DocLogGetAllForLocationLastXDays";
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sqlCommand.Parameters.Add("@DocType", SqlDbType.NVarChar, 30).Value = DocType.Trim();
            sqlCommand.Parameters.Add("@SubType", SqlDbType.NVarChar, 30).Value = SubType.Trim();
            sqlCommand.Parameters.Add("@LocationID", SqlDbType.UniqueIdentifier).Value = LocationID;
            if (LastXDays != null) { sqlCommand.Parameters.Add("@NumberOfDays", SqlDbType.Int).Value = LastXDays; }
    
            using( SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync(cancellationToken).ConfigureAwait(false) )
            {
                while (await sqlDataReader.ReadAsync(cancellationToken).ConfigureAwait(false))
                {
                    if (cancellationToken.IsCancellationRequested) break;
                    DocLog dl = readData(sqlDataReader);
                    dll.Add(dl);
                }
            }
        }
    
        return dll;
    }
