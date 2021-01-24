    public void setCarCmb(Cars car)
    {
        comboCars.SelectedIndex = comboCars.Items.Cast<Cars>().ToList().IndexOf(car);
        comboCars.Enabled = false;
    }
