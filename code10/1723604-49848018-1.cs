    public void ChangeTxtBlockText()
    {
        TextBlock tb = ViewMode.Current.txtblc_view_mode as TextBlock;
        if (tb != null)
        {
           tb.Text = "Hi";
        }
    }
