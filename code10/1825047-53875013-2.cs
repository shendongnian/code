      private bool _isSelected;
      public bool isSelected
      {
          get { return _isSelected; }
          set
          {
              _isSelected= value;
              // Call OnPropertyChanged whenever the property is updated
              OnPropertyChanged();
          }
      }
