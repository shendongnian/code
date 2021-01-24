    public class Boom<T> : ObsCol<T>
    {
        public override event NotifyCollectionChangedEventHandler CollectionChanged
        {
            add { throw new NotImplementedException(); }
            remove { }
        }
    }
