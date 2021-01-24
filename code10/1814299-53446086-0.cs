        public PersonsDashboardViewModel()
        {
            PersonList = new BindingList<Person>();
            PersonList.ListChanged += PersonList_ListChanged;
            PersonList.Add(new Person("Name1", "Lname1"));
            PersonList.Add(new Person("Name2", "Lname2"));
        }
        private void PersonList_ListChanged(object sender, ListChangedEventArgs e)
        {
            OnPropertyChanged(nameof(PersonCount));
        }
