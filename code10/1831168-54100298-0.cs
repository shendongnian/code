    public List<Person> PersonList { get; set; }
    public Person SelectedPerson { get; set; }
    private void InitializeDataBinding()
    {
        comboBox.DisplayMember = "FirstName";
        comboBox.DataSource = PersonList;
        textBoxFirstName.DataBindings.Add("Text", PersonList, "FirstName");
        textBoxLastName.DataBindings.Add("Text", PersonList, "LastName");
    }
    private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.SelectedPerson = (Person)(sender as ComboBox).SelectedItem;
    }
