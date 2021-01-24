    if (Double.TryParse(lbl_TotalAmount.Text, out double total) &&
        Double.TryParse(txt_DeliveryCharges.Text, out double charges))
    {
        sum = total + charges;
    }
    lbl_TotalAmount.Text = String.Format(sum.ToString("0.00"));
