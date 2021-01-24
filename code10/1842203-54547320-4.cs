    public void DisplayResults(double[] results)
    {
        try
        {  
            int q = 1;
            for (int i = 0; i <= 19; i++)
            {
                if (i == 0 || i == 11)
                {
                    if(i==0)
                        txtResults.Text += "Course Results";
                    else
                        txtResults.Text += "Professor Results";
                    if (results[i] == 1)
                    {
                        txtResults.Text += "Q" + i + ": Strongly Disagree";
                    }
                    else if (results[i] == 2)
                    {
                        txtResults.Text += "Q" + i + ": Disagree";
                    }
                    else if (results[i] == 3)
                    {
                        txtResults.Text += "Q" + i + ": Neutral";
                    }
                    else if (results[i] == 4)
                    {
                        txtResults.Text += "Q" + i + ": Agree";
                    }
                    else if (results[i] == 5)
                    {
                        txtResults.Text += "Q" + i + ": Strongly Agree ZERO";
                    }
                }
                else
                {
                    if (results[i] == 1)
                    {
                        txtResults.Text += "Q" + i + ": Strongly Disagree";
                    }
                    else if (results[i] == 2)
                    {
                        txtResults.Text += "Q" + i + ": Disagree";
                    }
                    else if (results[i] == 3)
                    {
                        txtResults.Text += "Q" + i + ": Neutral";
                    }
                    else if (results[i] == 4)
                    {
                        txtResults.Text += "Q" + i + ": Agree";
                    }
                    else if (results[i] == 5)
                    {
                        txtResults.Text += "Q" + i + ": Strongly Agree ZERO";
                    }
                }
            }
        }
        catch (Exception e)
        {
            Console.Write(e.Message, "Error");
        }
    }
