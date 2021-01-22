    private void checkExcelSettings()
    {
        // Now let's make sure we reflect what they are supposed to be in the GUI.
        chkbxExcelEnable.Checked = IsChecked("ExcelEnableHash");
        chkbxExcelSSN.Checked = IsChecked("ExcelSSNHash");
        chkbxExcelCC.Checked = IsChecked("ExcelCCHash");
        chkbxExcelWellsFargo.Checked = IsChecked("ExcelWellsHash");
    }
    private static bool IsChecked(string regValue)
    {
        return Convert.ToString(
                   Registry.GetValue(
                       @"HKEY_CURRENT_USER\Software\Mask Data\",
                       regValue,
                       "Unchecked")) == "Checked";
    }
