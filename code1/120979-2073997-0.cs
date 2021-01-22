    public CustomRow this[int i]
    {
       get { return new CustomRow(_RowCollection[i]); }
       set { _RowCollection[i] = value.Row; }
    }
