    public bool isValidDate(string datePart, string monthPart, string yearPart)
    {
        DateTime date;
        string strDate = string.Format("{0}-{1}-{2}", datePart, monthPart, yearPart);
        if (DateTime.TryParseExact(strDate, "dd-MM-yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo , System.Globalization.DateTimeStyles.None, out date ))
        {
            return true;
        }
        else
        {
            return false ;
        }
    }
