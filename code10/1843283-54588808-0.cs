    		private void ComboBox_OnToolTipOpening(object sender, ToolTipEventArgs e)
		    {
			    ComboBoxItem item = sender as ComboBoxItem;
			    if (item.Content.Equals("13.42"))
			    {
				    item.ToolTip = "ToolTipItem1";
			    }
			    else if (item.Content.Equals("15.82"))
			    {
			    	item.ToolTip = "ToolTipItem2";
			    }
		    }
