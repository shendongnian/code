    private void checkExcelSettings()
    {
        const string RegPath = @"HKEY_CURRENT_USER\Software\Mask Data\";
            // Read what the values are for the checkboxes first and assign them to a string.
            string _excelEnable = Convert.ToString(Registry.GetValue(RegPath, "ExcelEnableHash", "Unchecked"));
            string _excelSSN = Convert.ToString(Registry.GetValue(@"RegPath, "ExcelSSNHash", "Unchecked"));
            string _excelCC = Convert.ToString(Registry.GetValue(RegPath, "ExcelCCHash", "Unchecked"));
            string _excelWells = Convert.ToString(Registry.GetValue(RegPath, "ExcelWellsHash", "Unchecked"));
    
            // Now let's make sure we reflect what they are supposed to be in the GUI.
            chkbxExcelEnable.Checked = (_excelEnable == "Checked");
            chkbxExcelSSN.Checked = (_excelSSN  == "Checked");
            chkbxExcelCC.Checked = (_excelCC  == "Checked");
            chkbxExcelWellsFargo.Checked = (_excelWells  == "Checked");
    }
