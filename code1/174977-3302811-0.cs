    class BooleanWrapper : INotifyPropertyChanged
    {
      private Boolean isSelected;
      public Boolean IsSelected
      { 
        get { return isSelected; }
        set
        {
          if (isSelected != value)
          {
            isSelected = value;
            // TODO: Raise PropertyChanged event.
          }
        }
      }
    }
