    TestDataClassDataContext dc = new TestDataClassDataContext();
    Individual individual = dc.Individuals.Where(a => a.CustomerID == Convert.ToInt32(txtCustID.Text).FirstOrDefault();
    if(individual != null)
    {
       Contact contact = individual.Contacts.FirstOrDefault();
       if(contact != null)
       {
           txtFname.Text = contact.FirstName;
       }
    }
