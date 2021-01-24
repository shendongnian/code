    int correctAnswers = 0, incorrectAnswers = 0,
    	totalQuestions = grdquestions.Rows.Count;
    
    for(int i = 0; i < totalQuestions; i++)
    {
    	GridViewRow row = grdquestions.Rows[i];
    	string answer = dt.Rows[i]["Answer"].ToString();
    	
    	var radioButtons = new List<RadioButton>
    	{
    		(RadioButton)row.FindControl("Option1"),
    		(RadioButton)row.FindControl("Option2"),
    		(RadioButton)row.FindControl("Option3"),
    		(RadioButton)row.FindControl("Option4")
    	}
    	
    	foreach(var radioButton in radioButtons)
    	{
    		if (radioButton.Checked)
    		{
    			if(radioButton.Text == answer)
    				correctAnswers++;
    			else
    			{
    				incorrectAnswers++;
    				radioButton.ForeColor = Color.Red;
    				radioButton.Checked = false;
    			}
    		}
    		else if(radioButton.Text == answer)
    		{
    			radioButton.Checked = true;
    		}
    	}
    
    	// Not sure if this is supposed to be in the loop 
    	// or what you're even trying to do
    	/*
    	int marks = (int)dt.Rows[i]["Marks"];
    	
    	int total = index * marks;
    	Label2.Text = "FinalScore is :" + total;
    	*/
    }
    
    string correctAnswerPercentage = (correctAnswers / totalQuestions).ToString("0.00%");
