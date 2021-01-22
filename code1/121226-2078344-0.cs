    class A : INotifyPropertyChanged
    { 
      private string _sampleField;
      public string SampleField
      {
          get { return _sampleField; }
          set
          {
               _sampleField = value;
               OnPropertyChanged("SampleField");
          }
      };
    
      private B _classB
      public B ClassB
      {
          get { return _classB; }
          set
          {
               _classB = value;
               OnPropertyChanged("ClassB");
          }
      }
    
      public event PropertyChangedEventHandler PropertyChanged;
    
      protected virtual void OnPropertyChanged(string propertyName)
      {
          PropertyChangedEventHander handler = PropertyChanged;
          if (handler != null)
              handler(this, new PropertyChangedEventArgs(propertyName);
      }
    }
    
    class B : INotifyPropertyChanged
    {
      private string _fieldB;
      public string FieldB
      {
          get { return _fieldB; }
          set
          {
               _fieldB = value;
               OnPropertyChanged("FieldB");
          }
      }
    
      public event PropertyChangedEventHandler PropertyChanged;
    
      protected virtual void OnPropertyChanged(string propertyName)
      {
          PropertyChangedEventHander handler = PropertyChanged;
          if (handler != null)
              handler(this, new PropertyChangedEventArgs(propertyName);
      }
    }
