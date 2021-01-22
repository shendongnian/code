      private void ControlStateSwitch(bool state)
    {
        foreach (var x in from Control c in Page.Controls from Control x in c.Controls select x)
            if (ctrl is ASPxTextBox)
                ((ASPxTextBox)x).Enabled = status;
            else if (x is ASPxDateEdit)
                ((ASPxDateEdit)x).Enabled = status;
    }
