    public static string ReturnText(Control control)
    {
        switch (control)
        {
            case TextBox tb:
                return tb.Text;
            case ComboBox cb:
                return cb.SelectedText;
            //etc.
        }
    }
