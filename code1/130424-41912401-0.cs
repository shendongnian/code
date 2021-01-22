    using System.ComponentModel;
    namespace EnumSelectorTest
    {
      public class MainWindowVM : INotifyPropertyChanged
      {
        public EnumSelectorVM Selector { get; set; }
 
        private string _colorName;
        public string ColorName
        {
          get { return _colorName; }
          set
          {
            if (_colorName == value) return;
            _colorName = value;
            RaisePropertyChanged("ColorName");
          }
        }
        public MainWindowVM()
        {
          Selector = new EnumSelectorVM
            (
              typeof(MyColors),
              MyColors.Red,
              false,
              val => ColorName = "The color is " + ((MyColors)val).ToString()
            );
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void RaisePropertyChanged(string propertyName)
        {
          PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
      }
    }
