        public BindingList<Person> PersonList
        {
            get { return personList; }
            set
            {
                if (personList != null)
                    personList.ListChanged -= PersonList_ListChanged;
                personList = value;
                if (personList != null)
                    personList.ListChanged += PersonList_ListChanged;
                OnPropertyChanged(nameof(PersonList));
            }
        }
        public PersonsDashboardViewModel()
        {
            PersonList = new BindingList<Person>();
            PersonList.Add(new Person("Name1", "Lname1"));
            PersonList.Add(new Person("Name2", "Lname2"));
        }
        private void PersonList_ListChanged(object sender, ListChangedEventArgs e)
        {
            OnPropertyChanged(nameof(PersonCount));
        }
