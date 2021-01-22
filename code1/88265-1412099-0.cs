    private void checkExcelSettings()
    {
        // Read what the values are for the checkboxes first and assign them to a string.
        string _excelEnable = Convert.ToString(Registry.GetValue(@"HKEY_CURRENT_USER\Software\Mask Data\", "ExcelEnableHash", "Unchecked"));
        string _excelSSN = Convert.ToString(Registry.GetValue(@"HKEY_CURRENT_USER\Software\Mask Data\", "ExcelSSNHash", "Unchecked"));
        string _excelCC = Convert.ToString(Registry.GetValue(@"HKEY_CURRENT_USER\Software\Mask Data\", "ExcelCCHash", "Unchecked"));
        string _excelWells = Convert.ToString(Registry.GetValue(@"HKEY_CURRENT_USER\Software\Mask Data\", "ExcelWellsHash", "Unchecked"));
        // Now let's make sure we reflect what they are supposed to be in the GUI.
        chkbxExcelEnable.Checked = (_excelEnable == "Checked");
        chkbxExcelSSN.Checked = (_excelSSN == "Checked");
        chkbxExcelCC.Checked = (_excelCC == "Checked");
        chkbxExcelWellsFargo.Checked = (_excelWells == "Checked");
    }
