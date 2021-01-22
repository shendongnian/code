    	private void EnterKey(Object sender, KeyEventArgs e)
		{
			Key c = e.Key;
			if (!((c >= Key.A) && (c <= Key.F)))
			{
				if (!((c >= Key.D0) && (c <= Key.D9)))
				{
					if (!((c >= Key.NumPad0) && (c <= Key.NumPad9)))
					{
						e.Handled = true;
						LogText("Handled");
					}
				}
			}
		}
