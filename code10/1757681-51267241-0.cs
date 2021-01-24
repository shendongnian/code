    public class ReferenceDossier : INotifyPropertyChanged
        {
            private bool _selected;
            public bool Selected
            {
                get
                {
                    return _selected;
                }
                set
                {
                    _selected = value;
                    RaisePropertyChanged("Selected");
                }
            }
    }
