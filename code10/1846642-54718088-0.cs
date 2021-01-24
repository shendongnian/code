    private void DiscountCalculation(object sender, EventArgs e)
    {
        decimal Price = 0.0m;
        if (decimal.TryParse(PriceBox.Text, out Price) && Price < 100)
        {
            discountAmt = (Price * .1);
            MessageBox.Show($"The discount is {discountAmt}");
        }
    }
