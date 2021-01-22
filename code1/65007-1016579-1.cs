    private void WorksheetSelectionChange()
    {
    this.SelectionChange += 
        new Excel.DocEvents_SelectionChangeEventHandler(
        Worksheet1_SelectionChange);
    }
    void Worksheet1_SelectionChange(Excel.Range Target)
    {
    this.Application.StatusBar = this.Name + ":" +
        Target.get_Address(missing, missing,
        Excel.XlReferenceStyle.xlA1, missing, missing);
    }
