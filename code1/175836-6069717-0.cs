    /// <summary>
    /// Adds a small Infobox and a Validation with restriction (only these values will be selectable) to the specified cell.
    /// </summary>
    /// <param name="worksheet">The excel-sheet</param>
    /// <param name="rowNr">1-based row index of the cell that will contain the validation</param>
    /// <param name="columnNr">1-based column index of the cell that will contain the validation</param>
    /// <param name="title">Title of the Infobox</param>
    /// <param name="message">Message in the Infobox</param>
    /// <param name="validationValues">List of available values for selection of the cell. No other value, than this list is allowed to be used.</param>
    /// <exception cref="Exception">Thrown, if an error occurs, or the worksheet was null.</exception>
    public static void AddDataValidation(Worksheet worksheet, int rowNr, int columnNr, string title, string message, List<string> validationValues)
    {
        //If the message-string is too long (more than 255 characters, prune it)
        if (message.Length > 255)
            message = message.Substring(0, 254);
               
        try
        {
            //The validation requires a ';'-separated list of values, that will be the restrictions.
            //Fold the list, so you can add it as restriction. (Result is "Value1;Value2;Value3")
            //If you use another separation-character change the global Split-Character
            string values = string.Join(";", validationValues);
            //Select the specified cell
            Range cell = worksheet.Cells[rowNr, columnNr];
            //Delete any previous validation
            cell.Validation.Delete();
            //Add the validation, that only allowes selection of provided values.
            cell.Validation.Add(XlDVType.xlValidateList, XlDVAlertStyle.xlValidAlertStop, XlFormatConditionOperator.xlBetween, values, Type.Missing);
            cell.Validation.IgnoreBlank = true;
            //Optional put a message there
            cell.Validation.InputTitle = title;
            cell.Validation.InputMessage = message;
       }
       catch (Exception exception)
        {
             //This part should not be reached, but is used for stability-reasons
             throw new Exception(String.Format("Error when adding a Validation with restriction to the specified cell Row:{0}, Column:{1}, Message: {2}", rowNr, columnNr, message), exception);
            
        }
    }
