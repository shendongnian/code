    public static int getCheckedRadioButton(Control c)
    {
        Control.ControlCollection cc = c.Controls;
        for (int i = 0; i < cc.Count; i++)
        {
            RadioButton rb = cc[i] as RadioButton;
            if (rb.Checked)
            {
                return i;
            }
        }
        return 0;
    }
