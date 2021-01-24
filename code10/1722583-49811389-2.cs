        try
        {
            const string FILENAME = "TAInput.ini";
            string text = File.ReadAllText(FILENAME);
            Regex DEADZONE = new Regex($@"DeadZone=0\.(?!{nudInput.Value.ToString()}\b)(?<Ratio>\d[\d.]*)");
            int pos = 0;
            while (DEADZONE.IsMatch(text, pos)) 
            {
            	Match match = DEADZONE.Match(text);
	            int index = match.Groups["Ratio"].Index;
            	int length = match.Groups["Ratio"].Length;
            	pos = index+nudInput.Value.ToString().Length+1;
	            text = text.Remove(index, length);
         		text = text.Insert(index, $"{nudInput.Value.ToString()}\n");
            }
	        File.WriteAllText(FILENAME, text);
    	    Process.Start(FILENAME);
        }
        catch
        {
            MessageBox.Show("No");
        }
