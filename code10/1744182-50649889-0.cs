    public decimal AddDecimalStrings(params string[] decimals)
    {
        decimal result = 0;
        foreach (var str in decimals)
        {
            if (!String.IsNullOrWhiteSpace(str))
            {
                result += Convert.ToDecimal(str);
            }
        }
        return result;
    }
    private void decimalInput_TextChanged(object sender, EventArgs e)
    {
        var result = AddDecimalStrings(
                        till1Receipts.Text,
                        till1Accounts.Text,
                        till1WorldPay.Text,
                        till1Amex.Text,
                        till150Pound.Text,
                        till120Pound.Text,
                        till110Pound.Text,
                        till15pound.Text,
                        till11Pound.Text,
                        till150p.Text,
                        till120P.Text,
                        till110P.Text,
                        till15P.Text,
                        till1Copper.Text,
                        till1Float.Text);
        till1Revenue.Text = result.ToString();
    }
