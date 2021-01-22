    public CustomRow this[int i]
    {
       get
       {
          Row r = RowCollection[i];
          if (!_Dictionary.ContainsKey(r))
          {
             _Dictionary[r] = CustomRow(r);
          }
          return _Dictionary[r];
       }
       set
       {
          _Dictionary[value.Row] = value;
          RowCollection[i] = value.Row;
       }
    }
