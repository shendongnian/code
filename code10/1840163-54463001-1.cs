    Customer c;
    if(Id == 0) {
        c = new Customer(){ 
           Password = MyHelper.md5(txtPassword.Text),
           CreatedDate = DateTime.Now
        };
    }
    else
       c = db.Customers.FirstOrDefault(x => x.Id == Id);
    
    if (c != null {
        c.Address = txtAddress.Text;
        c.Name = txtName.Text;
        c.UserName = txtUserName.Text;
    
        if(Id != 0)
            db.Customers.Update(c);
        else
            db.Customers.Insert(c);
    
        db.SaveChanges();
    }
