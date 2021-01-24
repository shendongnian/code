            public void RefreshContact(int customerID)
        {
            CustomerDBEntities db = new CustomerDBEntities();
            var contacts = db.Contacts;         
            dataGridView_Contacts.Rows.Clear();
            if (customerID != 0)
            {
                int i = 0;
                foreach (var item in db.Customers.Where(x => x.PKCustomer == customerID).First().Contact.ToList())
                {
                    dataGridView_Contacts.Rows.Add();
                    dataGridView_Contacts.Rows[i].Cells[0].Value = item.PKAnsprechpartner;
                    dataGridView_Contacts.Rows[i].Cells[1].Value = item.Name;
                    dataGridView_Contacts.Rows[i].Cells[2].Value = item.Vorname;
                    i++;
                }
            }
        }
