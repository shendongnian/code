    using System;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Windows.Input;
    
    namespace Question_Answer_WPF_App
    {
        public class PersonViewModel : INotifyPropertyChanged
        {
            string firstName = "Bob";
            string lastName = "Smith";
            string fullName;
    
            public PersonViewModel()
            {
                CommitStateCommand = new RelayCommand((obj) => CommitChanges(),(obj) => CanExecuteCommands());
                RevertStateCommand = new RelayCommand((obj) => RevertChanges(),(obj) => CanExecuteCommands());
                CommitChanges();
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
            private void Notify([CallerMemberName] string property = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
    
            public string FirstName
            {
                get => firstName;
                set
                {
                    firstName = value;
                    Notify();
                    UpdateChanges();
                }
            }
    
            public string LastName
            {
                get => lastName;
                set
                {
                    lastName = value;
                    Notify();
                    UpdateChanges();
                }
            }
    
            public string FullName
            {
                get => fullName;
                private set
                {
                    fullName = value;
                    Notify();
                }
            }
    
            private PersonState PreviousState { get; } = new PersonState();
            public RelayCommand CommitStateCommand { get; }
            public RelayCommand RevertStateCommand { get; }
    
            private void UpdateChanges()
            {
                FullName = $"{FirstName} {LastName}";
                CommitStateCommand.UpdateCanExecute();
                RevertStateCommand.UpdateCanExecute();
            }
    
            private void CommitChanges()
            {
                PreviousState.FirstName = FirstName;
                PreviousState.LastName = LastName;
                UpdateChanges();
            }
    
            private void RevertChanges()
            {
                FirstName = PreviousState?.FirstName;
                LastName = PreviousState?.LastName;
                CommitChanges();
            }
    
            private bool CanExecuteCommands() => PreviousState?.FirstName != FirstName || PreviousState?.LastName != LastName;
        }
    
        internal class PersonState
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }
    
        public class RelayCommand : ICommand
        {
            public Action<object> ExecuteFunction { get; }
            public Predicate<object> CanExecutePredicate { get; }
            public event EventHandler CanExecuteChanged;
            public void UpdateCanExecute() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    
            public RelayCommand(Action<object> executeFunction) : this(executeFunction, (obj) => true) { }
            public RelayCommand(Action<object> executeFunction, Predicate<object> canExecutePredicate)
            {
                ExecuteFunction = executeFunction;
                CanExecutePredicate = canExecutePredicate;
            }
    
            public bool CanExecute(object parameter) => CanExecutePredicate?.Invoke(parameter) ?? true;
            public void Execute(object parameter) => ExecuteFunction.Invoke(parameter);
        }
    }
