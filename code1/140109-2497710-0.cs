    private void SetValidationBetweenNumbers() 
    { 
     
        Microsoft.Office.Tools.Excel.NamedRange cellThatNeedsValidating = 
            this.Controls.AddNamedRange(this.Range[""A1"", missing], 
            "cellThatNeedsValidating"); 
     
        cellThatNeedsValidating.Validation.Add( 
            Excel.XlDVType.xlValidateWholeNumber, 
            Excel.XlDVAlertStyle.xlValidAlertStop, 
            Excel.XlFormatConditionOperator.xlBetween, "1", "=B1"); 
    }
