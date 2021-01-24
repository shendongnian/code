    public List<object> CbxItemsSource { get; set; }
    private void InitCbxSource()
    {
    	var dblLst = new List<double>() { 1, 2, 3 };
    	CbxItemsSource = dblLst.Select(dbl => (object)new { ItemValue = dbl, ItemToolTip = "e.g. item index " + dblLst.IndexOf(dbl)}).ToList();
    }
