    public void SetDisabledStylingOnDropDown()
    {
        if ((ViewState["DisabledKeys"] != null) &&
            (EmpDropDown.Items.Count > 0))
        {
            List<string> disabledKeys = (List<string>)(ViewState["DisabledKeys"]);
            for (int i = 0; i < EmpDropDown.Items.Count; i++)
            {
                if (disabledKeys.Contains(EmpDropDown.Items[i].Value))
                {
                    EmpDropDown.Items[i].Attributes.Add("style", "background-color:red;"); 
                }
            }
        }
    }
