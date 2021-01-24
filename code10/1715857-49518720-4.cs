    private Book _book;
    public Book Book
        {
            get
            {
                return _book;
            }
            set
            {
                if (value == _book|| value == null)
                    return;
                if (_book!= null)
                    _book.PropertyChanged -= BookPropertyChanged;
                _book= value;
                _book.PropertyChanged += BookPropertyChanged;
                UpdateProperties();
            }
        }
