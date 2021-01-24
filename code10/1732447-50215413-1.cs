    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Initialize();
        }
        public void Initialize()
        {
            var ids = 0;
            var people = new List<PersonViewModel>()
            {
                new PersonViewModel() { Id = ids++, Name = "Mathew"},
                new PersonViewModel() { Id = ids++, Name = "Mark"},
                new PersonViewModel() { Id = ids++, Name = "Luke"},
                new PersonViewModel() { Id = ids++, Name = "John"}
            };
            foreach (var person in people)
            {
                var button = new Button()
                {
                    Content = person.Name,
                    Command = person.UpdatePersonCommand
                };
                SetCommandParameterBinding(button, person);
                button.Click += (s, e) => MessageBox.Show(button.CommandParameter.ToString());
                root.Children.Add(button);
            }
        }
        //This is the method that answers your question
        private static BindingExpressionBase SetCommandParameterBinding(ButtonBase button, PersonViewModel person)
        {
            //This sets a binding that binds the 'Name' property in PersonViewModel
            //Leave constructor parameter emtpy to bind to the object itself i.e. new Binding() { Source = Person }; will bind to person
            var binding = new Binding(nameof(PersonViewModel.Name)) { Source = person };
            //This sets the binding to the button and button CommandParameterProperty
            var bindingExpression = BindingOperations.SetBinding(button, ButtonBase.CommandParameterProperty, binding);
            return bindingExpression;
        }
    }
    //This isn't a fully written ViewModel obviously.  It's just here to make this example work.  INotifyPropertyChanged is not completely implemented.
    internal class PersonViewModel : INotifyPropertyChanged
    {
        public string Name { get; internal set; }
        public int Id { get; internal set; }
        public ICommand UpdatePersonCommand { get; internal set; }
        public event PropertyChangedEventHandler PropertyChanged;
    }
