	public void ItemDataBound(object sender, DataGridItemEventArgs e) {
			SalesPosition salesItem = e.Item.DataItem as SalesPosition;
			
			if(salesItem == null) return;
				
			if(salesItem.Type == SalesPositionType.Invoice)
				e.Item.BackColor = Color.Yellow;
			else if(salesItem.Type == SalesPositionType.Receipt)
				e.Item.BackColor = Color.Green;
		}
