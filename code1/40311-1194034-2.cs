    public string RemoveMultipleDelimiters(string sSingleLine)
    {
        string sMultipleDelimitersLine = "";
        string sMultipleDelimitersLine1 = "";
        int iDelimeterPosition = -1;
        iDelimeterPosition = sSingleLine.IndexOf('>');
        iDelimeterPosition = sSingleLine.IndexOf('>', iDelimeterPosition + 1);
        if (iDelimeterPosition > -1)
        {
            sMultipleDelimitersLine = sSingleLine.Substring(0, iDelimeterPosition - 1);
            sMultipleDelimitersLine1 = sSingleLine.Substring(sSingleLine.IndexOf('>', iDelimeterPosition) - 1);
            sMultipleDelimitersLine1 = sMultipleDelimitersLine1.Replace('>', '*');
            sSingleLine = sMultipleDelimitersLine + sMultipleDelimitersLine1;
        }
        return sSingleLine;
    }
