    public void DisplayResults(double[] results)
    {
        try
        {  
            for (int i = 0, q = 1; i <= 19; i++, q++)
            {
                if (i == 0 || i == 11)
                {
                    if(i == 0 )
                        txtResults.Text += "Course Results";
                    else
                        txtResults.Text += "Professor Results";
                }
                txtResults.Text += "Q" + q ": ";
				if (results[i] == 1)
				{
					txtResults.Text +="Strongly Disagree";
				}
				else if (results[i] == 2)
				{
					txtResults.Text +="Disagree";
				}
				else if (results[i] == 3)
				{
					txtResults.Text +=": Neutral";
				}
				else if (results[i] == 4)
				{
					txtResults.Text +="Agree";
				}
				else if (results[i] == 5)
				{
					if(i == 0 )
					txtResults.Text +="Strongly Agree ZERO";
					else if(i == 11 )
					txtResults.Text +="Strongly Agree ELEVEN";
					else
					txtResults.Text +="Strongly Agree";
				}
            }
        }
        catch (Exception e)
        {
            Console.Write(e.Message, "Error");
        }
    }
