    void MethodName()
    {
        txtToppingsReceipt.Text = "";
        foreach (CheckBox cbToppings in gbToppings.Controls)
        {
            if (cbToppings.Checked == true)
            {
    	        txtToppingsReceipt.Text += list[i].Text + Environment.NewLine;
                iToppings++;
            }
        }
    }
