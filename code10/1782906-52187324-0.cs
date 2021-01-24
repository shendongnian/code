    private void Button_Click(object sender, RoutedEventArgs e)
    {
        double price = double.Parse(TB_Price.Text);
        double commission = double.Parse(TB_Commission.Text);
        double result = result = commission * price;
        TB_Price.Text = price.ToString();
        TB_Result.Text = result.ToString();
    }
