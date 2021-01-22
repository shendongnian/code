`
 public class WindowManagerVM : GalaSoft.MvvmLight.ViewModelBase
    {
        public WindowManagerVM()
        {
            App.Current.Activated += (s, e) => IsAppActive = true;
            App.Current.Deactivated += (s, e) => IsAppActive = false;
        }
        private bool _isAppActive = true;
        public bool IsAppActive
        {
            get => _isAppActive;
            set
            {
                if (_isAppActive != value)
                {
                    _isAppActive = value;
                    RaisePropertyChanged(() => IsAppActive);
                }
            }
        }
    }
`
Here is the XAML that implements it (I use MVVM light with a ViewModelLocator as a static resource in my app called Locator):
`
<Window Topmost="{Binding WindowManager.IsAppActive, Source={StaticResource Locator}}"/>
`
        
