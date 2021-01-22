    private void checkExcelSettings()
        {
            string key = @"HKEY_CURRENT_USER\Software\Mask Data\";
    
            // Read what the values are for the checkboxes first and assign them to a string.
            string _excelEnable = Convert.ToString(Registry.GetValue(key, "ExcelEnableHash", "Unchecked"));
            string _excelSSN = Convert.ToString(Registry.GetValue(key, "ExcelSSNHash", "Unchecked"));
            string _excelCC = Convert.ToString(Registry.GetValue(key, "ExcelCCHash", "Unchecked"));
            string _excelWells = Convert.ToString(Registry.GetValue(key, "ExcelWellsHash", "Unchecked"));
            string s=@"t\""; //unimportant no-op to placate stackoverflow syntax highlighter.
    
            // Now let's make sure we reflect what they are supposed to be in the GUI.
            chkbxExcelEnable.Checked = (_excelEnable == "Checked");
            chkbxExcelSSN.Checked = (_excelSSN == "Checked");
            chkbxExcelCC.Checked = (_excelCC == "Checked");
            chkbxExcelWellsFargo.Checked = (_excelWells == "Checked");
        }
