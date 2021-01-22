		public void ItemDataBound(object sender, DataGridItemEventArgs e) {
				SalesPosition salesItem = e.Item.DataItem as SalesPosition;
				
				if(salesItem == null) return;
				
				if(salesItem.Type = MyTypes.Invoice)
								e.Item.BackColor = Color.Yellow;
				else
								e.Item.BackColor = Color.Green;
		}
