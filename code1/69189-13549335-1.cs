    private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
    {
           
            int gyear = dateTimePicker1.Value.Year; 
            int gmonth = dateTimePicker1.Value.Month; 
            int gday = dateTimePicker1.Value.Day; 
            int syear = DateTime.Now.Year; 
            int smonth = DateTime.Now.Month; 
            int sday = DateTime.Now.Day;
            int difday = DateTime.DaysInMonth(syear, gmonth);
            
            agedisplay = (syear - gyear); 
            
            lmonth = (smonth - gmonth);
            lday = (sday - gday);
            if (smonth < gmonth)
            {
                agedisplay = agedisplay - 1;
            }
            if (smonth == gmonth)
            {
                if (sday < (gday))
                {
                    agedisplay = agedisplay - 1;
                }
            }
            if (smonth < gmonth)
            {
                lmonth = (-(-smonth)+(-gmonth)+12);
            }
            if (lday < 0)
            {
                lday = difday - (-lday);
                lmonth = lmonth - 1;
            }
            if (smonth == gmonth && sday < gday&&gyear!=syear)
            {
                lmonth = 11;
            }
                ageDisplay.Text = Convert.ToString(agedisplay) + " Years,  " + lmonth + " Months,  " + lday + " Days.";
       
        }
