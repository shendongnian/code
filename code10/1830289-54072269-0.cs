		try {
		foreach (DataGridViewRow row in SaleGrid.Rows)
		{
			var saleProduct = new SaleProduct
			{
				SalesId = Convert.ToInt32(txtInvoice.Text),
				CatId = Convert.ToInt32(row.Cells["CatId"].Value ?? DBNull.Value),
				CatQuiltyId = Convert.ToInt32(row.Cells["QualityId"].Value ?? DBNull.Value),
				SuitDesignId = Convert.ToInt32(row.Cells["DesignId"].Value ?? DBNull.Value),
				SaleType = Convert.ToInt32(row.Cells["TypeId"].Value ?? DBNull.Value),
				StockId = Convert.ToInt32(row.Cells["StockId"].Value ?? DBNull.Value),
				Price = Convert.ToString(row.Cells["Price"].Value ?? DBNull.Value)
			};
			Db.SaleProducts.Add(saleProduct);
			Db.SaveChanges();
		}
		}
		catch (Exception e)
		{
		  var messages = new List<string>();
		  do
		  {
			messages.Add(e.Message);
			e = e.InnerException;
		  }
		  while (e != null) ;
		  var message = string.Join(" - ", messages);
		  MessageBox.Show(message);
		}
