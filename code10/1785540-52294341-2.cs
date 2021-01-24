    using System;
    using System.ComponentModel;
    using System.Windows.Input;
    
    namespace testApp.Views
    {
        public class Page1ViewModel:INotifyPropertyChanged
        {
            public Page1ViewModel()
            {
                SaveCommand = new Xamarin.Forms.Command(HandleAction);
                    
            }
    
            async void HandleAction(object obj)
            {
                await ((testApp.App)App.Current).MainPage.Navigation.PushAsync(new Page2(TextPropertyValue));
    
            }
            string entry1;
            public string TextPropertyValue
            {
                get
                {
                    return entry1;
                }
                set
                {
                    if (value!=entry1)
                    {
                        entry1 = value;
                        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TextPropertyValue)));
                    }
                }
            }
    
    
            public ICommand SaveCommand
            {
                get;
                set;
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
        }
    }
