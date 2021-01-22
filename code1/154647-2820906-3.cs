    #region DataSet manipulation
    ///<summary>Fills a the distance table of a dataset</summary>
    private void FillDataSet(ref DistanceDataTableAdapter taD, ref MyDataSet ds) {
      using (var myMRE = new ManualResetEventSlim(false)) {
        ds.EnforceConstraints = false;
        ds.Distance.BeginLoadData();
        Func<DistanceDataTable, int> distanceFill = taD.Fill;
        distanceFill.BeginInvoke(ds.Distance, FillCallback<DistanceDataTable>, new object[] { distanceFill, myMRE });
        WaitHandle.WaitAll(new []{ myMRE.WaitHandle });
        ds.Distance.EndLoadData();
        ds.EnforceConstraints = true;
      }
    }
    /// <summary>
    /// Callback used when filling a table asynchronously.
    /// </summary>
    /// <param name="result">Represents the status of the asynchronous operation.</param>
    private void FillCallback<MyDataTable>(IAsyncResult result) where MyDataTable: DataTable {
      var state = result.AsyncState as object[];
      Debug.Assert((state != null) && (state.Length == 2), "State variable is either null or an invalid number of parameters were passed.");
      var fillFunc = state[0] as Func<MyDataTable, int>;
      var mre = state[1] as ManualResetEventSlim;
      Debug.Assert((mre != null) && (fillFunc != null));
      int rowsAffected = fillFunc.EndInvoke(result);
      Debug.WriteLine(" Rows: " + rowsAffected.ToString());
      mre.Set();
    }
