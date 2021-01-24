    private void calculateButton_Click(object sender, EventArgs e)
    {
        var parsing = new[]
        {
            decimal.TryParse(startingTextBox.Text, out decimal approximatePopulation),
            decimal.TryParse(increaseTextBox.Text, out decimal averageIncrease),
            int.TryParse(daysTextBox.Text, out int numberOfDays),
        };
        if (parsing.All())
        {
            decimal increasePercent = averageIncrease / 100;
            int count = 1;
            do
            {
                outputListBox.Items.Add(count + "\t " + approximatePopulation + "\t" + increasePercent);
                approximatePopulation = (approximatePopulation + (approximatePopulation * increasePercent));
                count++;
             }
             while (count <= numberOfDays);
        }
    }
