    private ObservableCollection<CxC> _cuentasxcobrar;
    public ObservableCollection<CxC> CuentasxCobrar
    {
        set
        {
            if (_cuentasxcobrar != null)
                foreach (var item in _cuentasxcobrar)
                    item.PropertyChanged -= Item_PropertyChanged;
            _cuentasxcobrar = value;
            ActualizaImporteAcumulado();
            OnPropertyChanged("CuentasxCobrar");
            OnPropertyChanged("ImporteAcumulado");
            if (_cuentasxcobrar != null)
                foreach (var item in _cuentasxcobrar)
                    item.PropertyChanged += Item_PropertyChanged;
        }
        get { return _cuentasxcobrar; }
    }
    private void Item_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == "Selected")
            ActualizaImporteAcumulado();
    }
