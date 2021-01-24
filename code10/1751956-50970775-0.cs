	DateTime tempDate;
	if (DateTime.TryParse(userInputTextBox.Text, out tempDate))
	{
		Date Time newDate = new DateTime(tempDate.Year, tempDate.Month, DateTime.DaysInMonth(tempDate.Year, tempDate.Month));
		endOfMonthLabel.text = newDate.ToString("mm/dd/yyyy");
	}
	else
	{
		endOfMonthLabel.text = "invalid date format";
	}
