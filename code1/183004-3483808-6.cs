    using System.Collections.ObjectModel;
    using System.ComponentModel;
    
    namespace ComboBoxFilter
    {
        public class ViewModel : INotifyPropertyChanged
        {
            public ViewModel()
            {
                Names = new ObservableCollection<Person>
                            {
                                new Person {Name = "Andy"},
                                new Person {Name = "hkon"},
                                new Person {Name = "dandy"},
                                new Person {Name = "Andy"}
                            };
            }
    
            private Person _selectedPerson;
            public Person SelectedPerson
            {
                get { return _selectedPerson; }
                set { _selectedPerson = value; NotifyPropertyChanged("SelectedPerson"); }
            }
    
            public ObservableCollection<Person> Names { get; set; }
    
            public event PropertyChangedEventHandler PropertyChanged;
            public void NotifyPropertyChanged(string propertyName)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }
            }
        }
        public class Person
        {
            public string Name { get; set; }
    
            public override string ToString()
            {
                return Name;
            }
        }
    }
