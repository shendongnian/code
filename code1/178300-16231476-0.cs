        String strDate="12/20/2013";
        string strFormat="dd/MM/yyyy";
        DateTime objDT;
        if (DateTime.TryParseExact(strDate, strFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out objDT) == true)
        {
            Response.Write("<b>Formatted DateTime : </b>" + objDT.ToString());
        }
        else
        {
            Response.Write("<b>Not able to parse datetime.</b>");
        }
