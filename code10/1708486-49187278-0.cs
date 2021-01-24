	void MethodName()
	{
		List<CheckBox> list = new List<CheckBox>();
		foreach (CheckBox cbToppings in gbToppings.Controls)
		{
			if (cbToppings.Checked == true)
			{
				list.Add(cbToppings);
				iToppings++;
			}
		}
	
		txtToppingsReceipt.Text = "";
		for (Int32 i = 0; i < list.Count; i++)
		{
			txtToppingsReceipt.Text += Convert.ToString(list[i].Text + Environment.NewLine);
		}
	}
