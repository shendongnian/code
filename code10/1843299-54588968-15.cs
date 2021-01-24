    public List<object> CbxItemsSource { get; set; } = InitCbxSource();
    private static List<object> InitCbxSource()
    {
    	var dblLst = new List<double>() { 1, 2, 3 };
    	return dblLst.Select(dbl => (object)new { ItemValue = dbl, ItemToolTip = "e.g. item index " + dblLst.IndexOf(dbl)}).ToList();
    }
