    private void richText10_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
    {
	    var label7 = System.Convert.ToString(rptLabelForm.GetCurrentColumnValue("line_selling_price"));
        var percentage = 80M;
        var price = Decimal.Parse(label7, System.Globalization.NumberStyles.AllowCurrencySymbol | System.Globalization.NumberStyles.Number);
        var total = price * (percentage / 100M);
        richText10.Text = total.ToString();
    }
