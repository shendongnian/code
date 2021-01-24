    private List<DateTime> availableDates = new List<DateTime>();
    private void desktopDateTime_ValueChanged(object sender, EventArgs e)
        {
            bool isDuplicate = false;
            foreach(DateTime date in availableDates)
            //  ...
