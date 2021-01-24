    int correctAnswers = 0, incorrectAnswers = 0,
    	totalMarks = 0, totalQuestions = grdquestions.Rows.Count;
    
    for (int i = 0; i < totalQuestions; i++)
    {
    	GridViewRow row = grdquestions.Rows[i];
    	string answer = dt.Rows[i]["Answer"].ToString();
    	int marks = (int)dt.Rows[i]["Marks"];
    
    	var radioButtons = new List<RadioButton>
    	{
    		(RadioButton)row.FindControl("Option1"),
    		(RadioButton)row.FindControl("Option2"),
    		(RadioButton)row.FindControl("Option3"),
    		(RadioButton)row.FindControl("Option4")
    	}
    
    	foreach (var radioButton in radioButtons)
    	{
    		if (radioButton.Checked)
    		{
    			if (radioButton.Text == answer)
    			{
    				correctAnswers++;
    				totalMarks += marks;
    			}
    			else
    			{
    				incorrectAnswers++;
    				radioButton.Checked = false;
    			}
    		}
    		else if (radioButton.Text == answer)
    		{
    			radioButton.Checked = true;
    		}
    	}
    }
    
    Label2.Text = "FinalScore is :" + totalMarks;
    
    string correctAnswerPercentage = (correctAnswers / totalQuestions).ToString("0.00%");
