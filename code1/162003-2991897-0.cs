    public ObservableCollection<string> Answers
    {
        get { return _answers;  }
        set
        {
          // Detach the event handler from current instance, if any:
          if (_answers != null)
          {
             _answers.CollectionChanged -= _answers_CollectionChanged;
          }
          _answers = value;
          // Attatach the event handler to the new instance, if any:
          if (_answers != null)
          {
             _answers.CollectionChanged += _answers_CollectionChanged;
          }
          // Notify that the 'Answers' property has changed:
          onPropertyChanged("Answers");
        }
    }
    
    private void _answers_CollectionChanged(object sender,
	NotifyCollectionChangedEventArgs e)
    {
       onPropertyChanged("Answers");
    }
