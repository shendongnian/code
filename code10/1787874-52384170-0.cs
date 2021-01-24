    public class ChildWindowViewModel : ViewModelBase
    {
        public ChildWindowViewModel(BitmapImage image)
        {
            _imge = image;
        }
    
        private BitmapImage _imge;
        public BitmapImage Imge
        {
            get { return _imge; }
            set
            {
                _imge = value;
                RaisePropertyChanged("Imge");
            }
        }
    }
