    public new Color SelectedValue
    {
        get
        {
            //Asuming SelectedIndex is a valid int color value from your list
            if (SelectedIndex >= 0)
                return Color.FromArgb(SelectedIndex);
            return Color.White;
        }
 
