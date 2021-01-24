    else
	{
		if(decimal.TryParse(priceLabel.Text, out totalPrice))
		{
			cartComboBox.Items.Add(selectionListBox.SelectedItem);
			cost += totalPrice;
			totalPriceLabel.Text = cost.ToString("c");
		}
	}
