    protected void AgeButton_Click(object sender, EventArgs e)
        {
            DateTime Birth = new DateTime(1974, 8, 29);
            DateTime Today = DateTime.Now;
            TimeSpan Span = Today - Birth;
            DateTime Age = DateTime.MinValue + Span;
    	    //Make adjustment due to MinValue equalling 1/1/1
            int Years = Age.Year - 1;
            int Months = Age.Month - 1;
            int Days = Age.Day - 1;
    	    //Print out not only how many years old they are but give months and days as well
            Response.Write(Years.ToString() + " Years, " + Months.ToString() + " Months, " + Days.ToString() + " Days<br />");
        }
