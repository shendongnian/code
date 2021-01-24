    public string AppendSeates(string clickedText)
    {           
    	bool containsstr = btnsText.Any(word => btnsText.Contains(clickedText));
    	if(!containsstr)
    	{
    		btnsText = btnsText + " " + btnsText;
    	}           
    }
