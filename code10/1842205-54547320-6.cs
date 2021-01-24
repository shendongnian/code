    public void DisplayResults(double[] results)
    {
        try
        {  
            int q = 1;
            for (int i = 0; i <= 19; i++,q++)
            {
                if (i == 0 || i == 11)
                {
                    if(i==0)
                        txtResults.Text += "Course Results";
                    else
                        txtResults.Text += "Professor Results";
                    if (results[i] == 1)
                    {
                        txtResults.Text += "Q" + q + ": Strongly Disagree";
                    }
                    else if (results[i] == 2)
                    {
                        txtResults.Text += "Q" + q + ": Disagree";
                    }
                    else if (results[i] == 3)
                    {
                        txtResults.Text += "Q" + q + ": Neutral";
                    }
                    else if (results[i] == 4)
                    {
                        txtResults.Text += "Q" + q + ": Agree";
                    }
                    else if (results[i] == 5)
                    {
                        txtResults.Text += "Q" + q + ": Strongly Agree ZERO";
                    }
                }
                else
                {
                    if (results[i] == 1)
                    {
                        txtResults.Text += "Q" + q + ": Strongly Disagree";
                    }
                    else if (results[i] == 2)
                    {
                        txtResults.Text += "Q" + q + ": Disagree";
                    }
                    else if (results[i] == 3)
                    {
                        txtResults.Text += "Q" + q + ": Neutral";
                    }
                    else if (results[i] == 4)
                    {
                        txtResults.Text += "Q" + q + ": Agree";
                    }
                    else if (results[i] == 5)
                    {
                        txtResults.Text += "Q" + q + ": Strongly Agree ZERO";
                    }
                }
            }
        }
        catch (Exception e)
        {
            Console.Write(e.Message, "Error");
        }
    }
