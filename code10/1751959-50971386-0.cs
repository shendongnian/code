		private void Form1_Load(object sender, EventArgs e)
		{
			//add an item to the combobox at the top
				comboBox1.Items.Insert(0, "Please select an item");
			//set the text
				comboBox1.Text = "Please select an item";
		}
		private void comboBox1_DropDown(object sender, EventArgs e)
		{
			//when we click to open the dropdown, we remove that item
			if (comboBox1.Items.Contains("Please select an item"))
				comboBox1.Items.RemoveAt(0);
		}
		private void comboBox1_DropDownClosed(object sender, EventArgs e)
		{
			//when we close the dropdown, if we select an item the dropdown
			//displays that item, if now we set back to our text.
			if (comboBox1.SelectedIndex == -1)
			{
				comboBox1.Items.Insert(0, "Please select an item");
				comboBox1.Text = "Please select an item";
			}
		}
