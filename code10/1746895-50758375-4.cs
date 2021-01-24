    namespace ColumnsTest
    {
        using System.Windows.Input;
        using AgentOctal.WpfLib;
        using AgentOctal.WpfLib.Commands;
    
        class MainWindowVm : ViewModel
        {
            public MainWindowVm()
            {
                People = new ObservableCollection<PersonVm>();
            }
    
            public ObservableCollection<PersonVm> People { get; }
    
            private ICommand _addPersonCommand;
            public ICommand AddPersonCommand
            {
                get
                {
                    return _addPersonCommand ?? (_addPersonCommand = new SimpleCommand((obj) =>
                                            {
                                                People.Add(new PersonVm() { Name = Guid.NewGuid().ToString() });
                                            }));
                }
            }
    
        class PersonVm : ViewModel
        {
            private string _name;
            public string Name
            {
                get { return _name; }
                set { SetValue(ref _name, value); }
            }
    
        }
    }
