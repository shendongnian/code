    private void NotifyPropertyChanged(String info)
    {
       if (PropertyChanged != null)
       {
          PropertyChanged(this, new PropertyChangedEventArgs(info));
       }
    }
