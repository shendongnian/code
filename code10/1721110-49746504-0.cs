    private MyModelClass _Projekcik;
    public MyModelClass Projekcik
    {
        get => _Projekcik;
        set
        {
            if(Equals(value, _Projekcik)) return;
            if(_Projekcik != null)
                _Projekcik.PropertyChanged -= HandlePropertyChanged;
            _Projekcik = value;
            if(_Projekcik != null)
                _Projekcik.PropertyChanged += HandlePropertyChanged;
            void HandlePropertyChanged(object sender, PropertyChangedEventArgs e)
            {
                if (e.PropertyName == "abc")
                {
                    //Do your stuff here
                }
            }
        }
    }
