    public void set_CancelButton(IButtonControl value)
    {
        base.Properties.SetObject(PropCancelButton, value);
        if ((value != null) && (value.DialogResult == DialogResult.None))
        {
            value.DialogResult = DialogResult.Cancel;
        }
    }
