    public static void SetCarCmb(Car car)
    {
        comboCars.SelectedIndex = comboCars.Items.Cast<Car>().ToList().IndexOf(car);
        comboCars.Enabled = false;
    }
