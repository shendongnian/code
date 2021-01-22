    public event EventHandler<CollectionItemPropertyChangedEventArgs> CollectionItemPropertyChanged; 
 
    public void Add(object key, object item)
    {
        INotifyPropertyChanged notify = item as INotifyPropertyChanged; 
        if(notify != null)
        {
            notify.PropertyChanged += OnCollectionItemPropertyChanged; 
        }
    }
    private void OnCollectionItemPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        if(this.CollectionItemPropertyChanged != null)
        {
            CollectionItemPropertyChanged eventArgs = new CollectionItemPropertyChanged();
            eventArgs.Item = sender;
            eventArgs.Property = e.PropertyName; 
            this.this.CollectionItemPropertyChanged(this, eventArgs);
        }
    }
