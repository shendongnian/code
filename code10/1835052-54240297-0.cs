    public class ClassWrapper : BaseClassWrapper
    {
        public string SomeProperty { get; set; }
        public ClassWrapper()
        {
            Observable.FromEventPattern<NotifyCollectionChangedEventHandler, NotifyCollectionChangedEventArgs>
                    (x => ClassDTO.MyCollection.CollectionChanged += x, x => ClassDTO.MyCollection.CollectionChanged -= x)
                .Where(x => x.EventArgs.Action == NotifyCollectionChangedAction.Add ||
                            x.EventArgs.Action == NotifyCollectionChangedAction.Replace ||
                            x.EventArgs.Action == NotifyCollectionChangedAction.Remove)
                .Throttle( TimeSpan.FromMilliseconds(250))
                .Subscribe(x =>
                {
                    RaisePropertyChanged( ()=> SomeProperty);
                });
        }
    }
