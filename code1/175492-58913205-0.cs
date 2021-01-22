    if (obj != null)
    {
        if (obj is DateTime)
        {
            if (DateTime.MinValue == ((DateTime)obj))
            {
    
                xlWorkSheet.Cells[x,y] = String.Empty;
    
            }
            else
            {
    
                dynamic opp = ((DateTime)obj);
                xlWorkSheet.Cells[x,y] = (DateTime)opp;
    
            }
        }
    }
