            List<Person> personList = new List<Person>();
            personList.Add(new Person() {Name =  "Name1", Id=1 });
            personList.Add(new Person() { Name = "Name2", Id=2 });
            personList.Add(new Person() { Name = "Name3", Id=3 });
            personList.Add(new Person() { Name = "Name4", Id=4 });
            personList.Add(new Person() { Name = "Name5", Id=5 });
            comboBox1.DataSource = personList;
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "Id";
