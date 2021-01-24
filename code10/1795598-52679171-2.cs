    private void btnRemoveDupplicates_Click(object sender, EventArgs e)
    {
    	for (int i=0;i<listView1.Items.Count;i++)
    	{
    
    		var person = (Person)listView1.Items[i].Tag;
    		for (int j = 0; j < listView1.Items.Count; j++)
    		{
    			if(
    				((Person)listView1.Items[j].Tag).Name == person.Name && 
    				listView1.Items[i].Index != listView1.Items[j].Index)
    			{                        
    				listView1.Items[j].Remove();
    				continue;
    			}
    		}
    	}
    }
