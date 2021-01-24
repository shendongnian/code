    public void GetStockAllRecords()
    {
	    _ConnectionString = ConfigurationManager.
			ConnectionStrings["SimpleInventoryManagment_temp." +
			"Properties.Settings.dbInventoryMngConnectionString"].ToString();
		oDB = new Services.DE.SQLServer.DEDataContext(_ConnectionString);
		var stock = from t_stock in oDB.T_STOCKs
					select new
					{
						ID = t_stock.F_ID,
						Name = t_stock.F_NAME,
						Barcode = t_stock.F_BARCODE
					};
		DataGridViewItems  = stock;
	}
