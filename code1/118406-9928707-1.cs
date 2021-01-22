    value = this.GetDate()
    
    if (value.Length >= 6)//ensure that the date is mmddyy
    {
        int year = 0;
    
        if (int.TryParse(value.Substring(4, 2), out year))
        {
            int pastMillenium = int.Parse(DateTime.Now.ToString("yyyy").Substring(0, 2)) - 1;
    
            if (year > int.Parse(DateTime.Now.ToString("yy")))//if its a future year it's most likely 19XX
            {
                value = string.Format("{0}{1}{2}", value.Substring(0, 4), pastMillenium, year);
            }
            else
            {
                value = string.Format("{0}{1}{2}", value.Substring(0, 4), pastMillenium + 1, year);
            }
        }
        else
        {
            value = string.Empty;
        }
    }
    else
    {
        value = string.Empty;
    }
