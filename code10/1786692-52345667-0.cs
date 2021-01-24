    private IList<Person> _personList = new List<Person>();
    private void PopulateGrid()
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = _personList;
            dataGridView1.DataSource = bs;
        }
    private void AddPerson()
        {
            var count = _personList.Count;
            var finId = 0;
            if (count != 0)
            {
                var valid = _personList.LastOrDefault();
                if (valid != null)
                {
                    finId = valid.Id;
                } 
            }
            var person = new Person
            {
                Id = ++finId,
                FirstName = tbFirstName.Text,
                LastName = tbFirstName.Text,
                Email = tbEmail.Text,
                DateOfBirth = dtDateOfBirth.Value
            };
            MessageBox.Show("Successfully Added", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
            _personList.Add(person);
            this.PopulateGrid();
        }
