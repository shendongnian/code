    public class DataGridColumnCollection : ObservableCollection<DataGridColumn>
    {
    	private bool _DeferColumnChangeUpdates = false;
		public DataGridColumnCollection(bool deferColumnChangeUpdates, DataGrid dataGridOwner)
			: this(dataGridOwner)
		{
			_DeferColumnChangeUpdates = deferColumnChangeUpdates;
		}
        
        public DataGridColumnCollection(DataGrid dataGridOwner)
        {
            Debug.Assert(dataGridOwner != null, "We should have a valid DataGrid");
            DisplayIndexMap = new List<int>(5);
            _dataGridOwner = dataGridOwner;
            RealizedColumnsBlockListForNonVirtualizedRows = null;
            RealizedColumnsDisplayIndexBlockListForNonVirtualizedRows = null;
            RebuildRealizedColumnsBlockListForNonVirtualizedRows = true;
            RealizedColumnsBlockListForVirtualizedRows = null;
            RealizedColumnsDisplayIndexBlockListForVirtualizedRows = null;
            RebuildRealizedColumnsBlockListForVirtualizedRows = true;
        }
        #region Protected Overrides
		public void ForceUpdate()
		{
			if (DisplayIndexMapInitialized)
			{
				UpdateDisplayIndexForNewColumns(this, 0);
			}
			InvalidateHasVisibleStarColumns();
		}
    	protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
				if (!_DeferColumnChangeUpdates)
				{
					if (DisplayIndexMapInitialized)
					{
						UpdateDisplayIndexForNewColumns(e.NewItems, e.NewStartingIndex);
					}
					InvalidateHasVisibleStarColumns();
				}
            		break;
