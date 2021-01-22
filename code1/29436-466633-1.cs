    Person iSomeView.Person
    {
    	get { return new Person { Name = txtName.Text, Phone = txtPhone.Text }; }
    	set { txtName = value.Name; txtPhone.Text = value.Phone; }
    }
