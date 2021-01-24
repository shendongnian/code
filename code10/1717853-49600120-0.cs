    public class PersonsViewModel
    {
            private RelayCommand _addPersonCommand = null;
            public RelayCommand AddPersonCommand
            {
                get
                {
                    return _addPersonCommand ?? (_addPersonCommand = new RelayCommand(
                        () =>
                        {
                            Action<Person> callback = (person) =>
                            {
                                _persons.Add(person);
                                RaisePropertyChanged("Persons");
                            };
     
                            Messenger.Default.Send<NotificationMessageAction<Person>>(new NotificationMessageAction<Person>(this, new Person(), "myNotification", callback), this);          
                        }));
                }
            }
    }
    
    private PersonsViewModel _viewModel = null;
    public PersonsView()
    {
         InitializeComponent();
      
         DataContext = _viewModel = new PersonsViewModel();
         Messenger.Default.Register<NotificationMessageAction<Person>>(this, _viewModel, message => 
         {
              if(message.Notification == "myNotification")
              {
                    Person person = (Person)message.Target;
                    Action<Person> callback = message.Execute;
                    ModalView view = new ModalView(person);
                    if(true == view.ShowDialog())
                    {
                          callback.Invoke(view.Person);
                    }
              }
          });
    }
