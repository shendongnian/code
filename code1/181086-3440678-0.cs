    List<CheckBox> checked = new List<CheckBox>();
    foreach (CheckBox chk in gpbSchedule.Controls.OfType<CheckBox>())
    {
        if (chk.Checked)
        {
            checked.Add(chk);
        }
    }
    for(int i = 0; i < checked.Count; i++)
    {
        if (i == checked.Count-1))
        {
            //write for last element
        }
        else
        {
            //write for all other elements
        }
    }
