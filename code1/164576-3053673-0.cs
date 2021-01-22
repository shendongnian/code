    private Control FindControl(Control ctr, string name)
    {
        Control c = null;
        for (int i = 0; i < ctr.Controls.Count; i++)
        {
            if (string.Equals(ctr.Controls[i].ID, name, StringComparison.CurrentCultureIgnoreCase))
            {
                c = ctr.Controls[i];
                break;
            }
            if (ctr.Controls[i].Controls.Count > 0)
            {
                c = FindControl(ctr.Controls[i], name);
                if (c != null)
                    break;
            }
        }
        return c;
    }
