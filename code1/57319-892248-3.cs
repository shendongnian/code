    public T this[Int32 index]
    {
        get { return _List[index]; }
        set {
            T oldItem = _List[index];
            _List[index] = value;
            if (oldItem != value)
            {
                if (oldItem != null)
                    oldItem.PropertyChanged -= ItemPropertyChanged;
                if (value != null)
                    value.PropertyChanged += ItemPropertyChanged;
            }
        }
    }
