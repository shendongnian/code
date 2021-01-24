    string comboSelectedValue = ActionTimerComboBox.SelectedValue;
	double selectedVal =0.0;
	if(double.TryParse(comboSelectedValue, out selectedVal)){
        settings.ActionTimer = (int)TimeSpan.FromMinutes(selectedVal).TotalMilliseconds;
	    Console.WriteLine(TimeSpan.FromMinutes(selectedVal).TotalMilliseconds);
	}
	else
	{
	    Console.WriteLine("Error in conversion");
	}
