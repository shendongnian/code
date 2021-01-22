    private void SetValidation()
    {
    
        Microsoft.Office.Tools.Excel.NamedRange listValidatingRange =
            this.Controls.AddNamedRange(this.Range[""C1:C13"", missing],
            "ListValidatingRange");
    
        Microsoft.Office.Tools.Excel.NamedRange cellThatNeedsValidating =
            this.Controls.AddNamedRange(this.Range[""A1"", missing],
            "cellThatNeedsValidating");
    
        cellThatNeedsValidating.Validation.Add(
            Excel.XlDVType.xlValidateList ,
            Excel.XlDVAlertStyle.xlValidAlertStop,
            missing, "=ListValidatingRange", missing);
    }
