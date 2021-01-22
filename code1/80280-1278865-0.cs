    if (!checkBox1.Checked && !checkBox2.Checked)
    {
    	MessageBox.Show("Please select at least one!");
    }
    else if (checkBox1.Checked && !checkBox2.Checked)
    {
    	MessageBox.Show("You selected the first one!");
    }
    else if (!checkBox1.Checked && checkBox2.Checked)
    {
    	MessageBox.Show("You selected the second one!");
    }
    else //Both are checked
    {
    	MessageBox.Show("You selected both!");
    }
