        decimal decimalValue;
        NumberFormatInfo formatWithPeriod = CultureInfo.InvariantCulture.NumberFormat;
        if (!Decimal.TryParse(textBox.Text, NumberStyles.AllowDecimalPoint, formatWithPeriod, out decimalValue))
        {
            NumberFormatInfo formatWithComma = (NumberFormatInfo)formatWithPeriod.Clone();
            formatWithComma.NumberDecimalSeparator = ",";
            if (!Decimal.TryParse(textBox.Text, NumberStyles.AllowDecimalPoint, formatWithComma, out decimalValue))
            {
                //error here
                return;
            }
        }
        con.Open();
        SqlCommand cmd = new SqlCommand("Insert into inventory (price) values (@price);", con);
        var priceParameter = cmd.Parameters.Add("@price", SqlDbType.Decimal);
        priceParameter.Precision = 18;
        priceParameter.Scale = 2;
        priceParameter.Value = decimalValue;
        cmd.ExecuteNonQuery();
        con.Close();
