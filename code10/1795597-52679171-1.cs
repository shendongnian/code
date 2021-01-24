    private void frmMain_Load(object sender, EventArgs e)
    {
    	var list = new List<Person>()
    	{
    		new Person() { Age = 24 , Job = "Engineer", Name = "John" },
    		new Person() { Age = 32, Job = "Golfer", Name = "Tom " },
    		new Person() { Age = 55, Job = "Scientist",Name = "John" },
    	};
    
    
    	foreach (var person in list)
    	{
    		ListViewItem item = new ListViewItem(person.Name);
    		item.Tag = person;
    
    		listView1.Items.Add(item);
    	}
    }
