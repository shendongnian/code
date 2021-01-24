    string totalToppings = string.Empty;
    foreach (CheckBox cbToppings in gbToppings.Controls)
    {
        if (cbToppings.Checked == true)
        {
            totalToppings += cbToppings.Text + Environment.NewLine;
            iToppings++;
        }
    }
    
    txtToppingsReceipt.Text = totalToppings;
