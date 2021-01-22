    public static int getCheckedRadioButton(Control c)
    {
        int i;
        try
        {
            Control.ControlCollection cc = c.Controls;
            for (i = 0; i < cc.Count; i++)
            {
                RadioButton rb = cc[i] as RadioButton;
                if (rb.Checked)
                {
                    return i;
                }
            }
        }
        catch
        {
            i = -1;
        }
        return i;
    }
