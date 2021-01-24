       private ObservableCollection<SaleInvoiceDetialDataGridViewModel> _DataGridCollection = new ObservableCollection<SaleInvoiceDetialDataGridViewModel>();
    
            public ObservableCollection<SaleInvoiceDetialDataGridViewModel> DataGridCollection
            {
                get
                {
                    return _DataGridCollection;
                }
                set
                {
                    _DataGridCollection = value;
                    OnPropertyChanged("DataGridCollection");
                }
            }
