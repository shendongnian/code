	public void OnAction_Dropdown(Office.IRibbonControl control, string itemId, int index)
	{
		try
		{
			switch (control.Id) //do a lookup of the value from your list based on the index
			{
				case "TripBooking_Tab_AddMeetingBefore":
					// set a variable here
					break;
				case "TripBooking_Tab_AddMeetingAfter":
					// set a variable here
					break;
				default:
					break;
			}
		}
		catch (Exception ex)
		{
			// format message
			var userMessage = new StringBuilder()
				.AppendLine("Contact your system administrator.")
				.AppendLine("Procedure: " + caller.Name.Trim())
				.AppendLine("Description: " + ex.ToString())
				.ToString();
			MessageBox.Show(userMessage, "Unexpected Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}
	}
