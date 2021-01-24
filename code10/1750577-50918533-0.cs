    using System.ComponentModel;
    using WpfApp1.Model;
    namespace WpfApp1.Model
    {
        public class NestedObjectModel
        {
            public string Text { get; set; }
            public double Number { get; set; }
        }
    }
    namespace WpfApp1.ViewModels
    {
        class MyViewModel: INotifyPropertyChanged
        {
            private string _viewModelProperty;
            private NestedObjectModel _nestedObject;
            public event PropertyChangedEventHandler PropertyChanged;
            public string ViewModelProperty
            {
                get { return _viewModelProperty; }
                set {
                    _viewModelProperty = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ViewModelProperty"));
                    ChangeTextInNestedObject(value);
                }
        }
        public NestedObjectModel NestedObject
        {
            get { return _nestedObject; }
            set {
                _nestedObject = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("NestedObject"));
            }
        }
        public MyViewModel()
        {
            _nestedObject = new NestedObjectModel() { Text = "TExt", Number = 321.1 };
        }
        public void ChangeTextInNestedObject(string newText)
        {
            _nestedObject.Text = newText;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("NestedObject"));
        }
        }
    }
