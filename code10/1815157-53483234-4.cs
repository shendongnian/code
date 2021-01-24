    public TSource SelectedValue
    {
         get => return (TSource)base.SelectedValue;
         set
         {
             // TODO: check if value is in ComboItems
             base.SelectedValue = value;
         }
    }
  
