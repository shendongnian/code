    protected void btnAdd_Click(object sender, EventArgs e)
    {
    	try
    	{
    		foreach (RadComboBoxItem item in comboNames.CheckedItems)
    		{
    			int contID = Convert.ToInt32(item.Value);
    			tbl_contacts cont = db.tbl_contacts
    									.Where(c => c.cont_id == contID)
    									.FirstOrDefault();
    			cont.cont = true;
    			db.SaveChanges();
    		}
    
    		gridContacts.Rebind();
    	}
    	catch (Exception ex)
    	{
    		//Add your exception logic here
    	}
    }
