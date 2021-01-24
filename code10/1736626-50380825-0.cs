    private void textBox4_TextChanged(object sender, EventArgs e)
    {
    	if (Properties.Settings.Default.Accounts != null)
    	{
    		listBox1.BeginUpdate();
    		listBox1.Items.Clear();
    		if (!String.IsNullOrEmpty(textBox4.Text))
    		{
    			foreach (var account in Properties.Settings.Default.Accounts)
    			{
    				if (account.Name.Contains(textBox4.Text))
    				{
    					listBox1.Items.Add(account);
    				}
    			}
    			
    		}
    		else //there is no any filter string, so add all data we have in Store
    		{
    			foreach (var account in Properties.Settings.Default.Accounts)
    			{
    				listBox1.Items.Add(account);
    			}
    		}
    		
    		listBox1.EndUpdate();
    	}
    }
