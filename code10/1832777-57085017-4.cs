    using System;
    using System.Runtime.CompilerServices;
    namespace MVVMListAndDetailExample.ViewModels
    {
        public class PersonViewModel : BaseViewModel
        {
            public PersonViewModel(Models.Person person)
            {
                this.person = person;
                firstName = person.FirstName;
                lastName = person.LastName;
                age = person.Age;
                city = person.City;
                state = person.State;
            }
            Models.Person person;
            string firstName;
            string lastName;
            int age;
            string city;
            string state; 
            public string FirstName
            {
                get { return firstName; }
                set
                {
                    if (firstName != value)
                    {
                        firstName = value;
                        OnPropertyChanged();
                    
                    }
                }
            }
            public string LastName
            {
                get { return lastName; }
                set
                {
                    if (lastName != value)
                    {
                        lastName = value;
                        OnPropertyChanged();
                    }
                }
            }
            public int Age
            {
                get { return age; }
                set
                {
                    if (age != value)
                    {
                        age = value;
                        OnPropertyChanged();
                    }
                }
            }
            public string City
            {
                get { return city; }
                set
                {
                    if (city != value)
                    {
                        city = value;
                        OnPropertyChanged();
                    }
                }
            }
            public string State
            {
                get { return state; }
                set
                {
                    if (state != value)
                    {
                        state = value;
                        OnPropertyChanged();
                    }
                }
            }
            protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                base.OnPropertyChanged(propertyName);
                Models.People.Instance.PeopleList[Models.People.Instance.PeopleList.FindIndex(ind=>ind.Equals(person))] = person;
            }
        }
    }
