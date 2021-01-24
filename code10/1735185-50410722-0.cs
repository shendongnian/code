    private void loadproductName()
    {
      DataTable dt = _poshelper.getproductName("Bill_Select_ProductName");
      if (dt.Rows.Count != 0)
      {
        string[] postSource = dt
                .AsEnumerable()
                .Select<System.Data.DataRow, String>(x => x.Field<String>("UniqueName"))
                .ToArray();
        var source = new AutoCompleteStringCollection();
        source.AddRange(postSource);
        txtItemName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
        txtItemName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
        txtItemName.AutoCompleteCustomSource = source;
      }
    }
