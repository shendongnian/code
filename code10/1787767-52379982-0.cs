    private void GetListControl(Control controlCollection, ref List<DropDownList> dropDownCollection)
    {
        foreach (Control c in controlCollection.Controls)
        {
            foreach (Control childc in c.Controls)
            {
                if (childc != null)
                {
                    if (childc is DropDownList)
                    {
                        if (childc.ID.StartsWith("WH"))
                        dropDownCollection.Add((DropDownList)childc);
                    }
                    if (childc.HasControls())
                        GetListControl(childc, ref dropDownCollection);
                    }
                }
            }
        }
