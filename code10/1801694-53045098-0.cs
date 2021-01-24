    using System.Collections.ObjectModel;
    
    namespace WpfApp1
    {
        public class MainWindowViewmodel
        {
            public ObservableCollection<string> Messages { get; set; }
            public MainWindowViewmodel()
            {
                Messages = new ObservableCollection<string>();
                Messages.Add("My message!");
                ChangeMessageCommand = new RelayCommand(ChangeMessageExcecute); 
            }
            public RelayCommand ChangeMessageCommand { get; set; }
            private void ChangeMessageExcecute() => Messages[0] = "NEW message!";
        }
    }
