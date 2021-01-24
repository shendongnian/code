    txtToppingsReceipt.Text = "";
    list.Clear();
    //Displays toppings in receipt
    foreach (CheckBox cbToppings in gbToppings.Controls)
    {
        if (cbToppings.Checked == true)
        {
            list.Add(cbToppings);
            iToppings++;
        }
    }
    for (Int32 i = 0; i < list.Count; i++)
    {
        txtToppingsReceipt.Text += Convert.ToString(list[i].Text + Environment.NewLine);
    }
