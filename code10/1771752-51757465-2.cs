    using System;
    using System.Collections.ObjectModel;
    using System.Windows.Input;
    
    using GalaSoft.MvvmLight;
    using GalaSoft.MvvmLight.CommandWpf;
    
    namespace Test
    {
        public class MainViewModel : ViewModelBase
        {
            public class TestModel
            {
                public string Value { get; set; }
    
                public TestModel(string value)
                {
                    this.Value = value;
                }
            }
    
            public ObservableCollection<string> ListBoxItems { get; set; }
    
            public ICommand ListBoxLeftClickCommand { get; }
    
            public MainViewModel()
            {
                ListBoxLeftClickCommand = new RelayCommand<object>(DoSomething, selectedItem => true);
                ListBoxItems = new ObservableCollection<string>() { "Test1", "Test2" };
            }
    
            private void DoSomething(object selectedItem)
            {
                throw new NotImplementedException();
            }
        }
    }
