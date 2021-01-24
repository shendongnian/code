    private void ArduinoTMR_Tick(object sender, EventArgs e)
    {
    	string ard1 = Arduino.ReadLine();
    
    	label2.Text = ard1;
    	
    	if(!int.TryParse(ard1, out var state)) return; // try to convert text to a number
    	label2.BackColor = state > 0 ? Color.Red : Color.Blue; // now compare the parsed number to the number 0
    }
