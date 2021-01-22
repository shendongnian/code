    using System;
    using Excel = Microsoft.Office.Interop.Excel;
    using Microsoft.Office.Interop.Excel;
    /// <summary>
    /// setup this cell to validate (and report error) as decimal value input
    /// </summary>
    void SetupCellValidation_decimal(Excel.Range cell)
    {
      try
      {
        // Delete any previous validation
        cell.Validation.Delete();
        // Add validation that allows any decimal value
        cell.Validation.Add(Excel.XlDVType.xlValidateDecimal, Excel.XlDVAlertStyle.xlValidAlertStop,
          Excel.XlFormatConditionOperator.xlBetween, decimal.MinValue, decimal.MaxValue);
        cell.Validation.IgnoreBlank = true; // allow blank entries
        cell.Validation.ErrorTitle = "Invalid Entry";
        cell.Validation.ErrorMessage = "You must enter a valid number";
      }
      catch (Exception ex)
      {
        System.Windows.Forms.MessageBox.Show("validate error: " + ex.Message);
      }
    }
    /// <summary>
    /// 
    /// </summary>
    void exampleCellValidator(Excel.Range cell)
    {
      try
      {
        //Delete any previous validation
        cell.Validation.Delete();
        // for integers:
        cell.Validation.Add(Excel.XlDVType.xlValidateWholeNumber, Excel.XlDVAlertStyle.xlValidAlertStop,
          Excel.XlFormatConditionOperator.xlBetween, 0, 120);
        // for decimal:
        cell.Validation.Add(Excel.XlDVType.xlValidateDecimal, Excel.XlDVAlertStyle.xlValidAlertStop,
          Excel.XlFormatConditionOperator.xlBetween, decimal.MinValue, decimal.MaxValue);
        cell.Validation.IgnoreBlank = true;
        // error messaging
        cell.Validation.ErrorMessage = "Entry is not a valid number";
        cell.Validation.ErrorTitle = "Error - invalid entry";
        // use these if you want to display a message each time user activates this cell
        cell.Validation.InputTitle = "Entry Rule"; // a message box title
        cell.Validation.InputMessage = "You must enter a valid number"; // message to instruct user what to do
      }
      catch (Exception ex)
      {
        System.Windows.Forms.MessageBox.Show("validate error: " + ex.Message);
      }
    }
