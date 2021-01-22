    class PersonModel {
        public string Name { get; set; }
    }
    class PersonViewModel {
        private PersonModel Person { get; set;}
        public string Name { get { return this.Person.Name; } }
        public bool IsSelected { get; set; } // example of state exposed by view model
        public PersonViewModel(PersonModel person) {
            this.Person = person;
        }
    }
