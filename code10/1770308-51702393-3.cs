    public string AppendSeats(string clickedText)
    {           
    	bool containsstr = btnsText.Any(word => btnsText.Contains(clickedText));
    	if(!containsstr)
    	{
            //Here adding space, you can add comma, dot etc..
    		btnsText = btnsText + " " + btnsText;
    	}           
    }
