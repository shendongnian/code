    private void button1_Click(object sender, EventArgs e)
    {    	
    	if (checkBox1.Checked == true)
        {
            locations.Add(checkBox1.Text);
        }
    	else
    	{
    		locations.Remove(checkBox1.Text);
    	}
        // and so on for other locations
    }
