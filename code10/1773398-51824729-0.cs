    public class ViewModelInvoiceProduct : INotifyPropertyChanged
    {
       //only the properties in Model that you want to show in DataGrid
       //your additional property
       private int _CGST;
       public int CGST
        {
            get
            {
                return _CGST;
            }
            set
            {
                _CGST = value;
                RaisePropertyChanged("CGST");
            }
        }
    }
