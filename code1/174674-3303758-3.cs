    private void RaisePropertyChanged(string property)
    {
      if ( PropertyChanged != null )
      {
        UiHelper.SafeDispatch(() =>
          PropertyChanged(this, new PropertyChangedEventArgs(property)));
      }
    }
