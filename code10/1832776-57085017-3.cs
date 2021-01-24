    using System;
    using System.Collections.ObjectModel;
    namespace MVVMListAndDetailExample.ViewModels
    {
        public class MainPageViewModel : BaseViewModel
        {
            ObservableCollection<PersonViewModel> peopleList = new ObservableCollection<PersonViewModel>();
            public ObservableCollection<PersonViewModel> PeopleList
            {
                get { return peopleList; }
                set
                {
                    if (peopleList != value)
                    {
                        peopleList = value;
                        OnPropertyChanged();
                    }
                }
            }
            public MainPageViewModel()
            {
                foreach(Models.Person person in Models.People.Instance.PeopleList)
                {
                    peopleList.Add(new PersonViewModel(person));
                }
            }
        }
    }
