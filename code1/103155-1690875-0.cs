    bool bInternalChange = false;
    private void ComboBoxF_SelectionChanged(...)
    {
        if (!bInternalChange)
        {
            bInternalChange = true;
            ComboBoxC.SelectedValue = ConvertFtoC(...);
            bInternalChange = false;
        }
    }
    private void ComboBoxC_SelectionChanged(...)
    {
        if (!bInternalChange)
        {
            bInternalChange = true;
            ComboBoxF.SelectedValue = ConvertCtoF(...);
            bInternalChange = false;
        }
    }
