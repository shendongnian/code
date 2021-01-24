	// VARIABLES
	double inputTemperature;  // Stores user input
	
	// INPUT
	if (!double.TryParse(txtTemperature.Text, out inputTemperature))  // Checking that user input is valid
	{
        MessageBox.Show("ERROR: Please enter a numeric temperature to convert.");  // Error message that is displayed
        txtTemperature.ResetText();  // Resets the form
        txtTemperature.Focus();  // Places the user's cursor back in the Temperature textbox
	}
	// PROCESSING
	if (optCelsius.Checked)  // If the celsius button is clicked, then the temperature needs to be converted from fahrenheit
	{
		lblNewTemperature.Text = $"{inputTemperature} degrees Celsius converts to {(inputTemperature - 32) * 5 / 9} degrees Fahrenheit.";
	}
	else if (optFahrenheit.Checked)  // If the fahrenheit button is clicked, then the temperature needs to be converted from celsius
	{
		lblNewTemperature.Text = $"{inputTemperature} degrees Fahrenheit converts to {(inputTemperature * 9) / 5 + 32} degrees Celsius.";
	}
