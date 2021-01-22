    private int CalculateDays(DateTime start, DateTime end )
    {
       DateTime origin = new DateTime(); 
       return (end - origin).Days - (start - origin).Days;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        // Parse dates for correctness and range errors, warn as necessary
        DateTime start;
        DateTime end;
        // rough error implement error handling implementation   
        string errors = string.Empty;
             if(!DateTime.TryParse(txt_start_date.Text.Trim(), out start))   errors+="Start date was incorrect";
        else if(!DateTime.TryParse(txt_end_date.Text.Trim(), out end))   errors+= (errors.Length>0? errors+= "\n":"") + "End date was incorrect" ; 
        else if ((end.Day - start.Day) <= 0) errors+= (errors.Length>0? errors+= "\n":"" ) + "End date must be greater than the Start date" ;         //CultureInfo.InvariantCulture
        else 
        {
            Response.Write(CalculateDays(start, end)); 
        }
        Debug.Assert(errors.Length <= 0, errors); 
    }
