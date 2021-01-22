    using System.Windows;
    using System.ComponentModel;
    namespace TestBackground88238
    {
        public partial class Window1 : Window, INotifyPropertyChanged
        {
            #region ViewModelProperty: Background
            private Color _background;
            public Color Background
            {
                get
                {
                    return _background;
                }
                set
                {
                    _background = value;
                    OnPropertyChanged("Background");
                }
            }
            #endregion
    
            //...//
    }
