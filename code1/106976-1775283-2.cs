    public interface INotifyCollectionChanged
    {
        event CollectionChangingEventHandler CollectionChanging;
    }
    public delegate void CollectionChangingEventHandler(
        object source, 
        CollectionChangingEventArgs e
    );
    /// <remarks>  This should parallel CollectionChangedEventArgs.  the same
    /// information should be passed to that event. </remarks>
    public class CollectionChangingEventArgs : EventArgs
    {
        // appropriate .ctors here
        public NotifyCollectionChangedAction Action { get; private set; }
        public IList NewItems { get; private set; }
        public int NewStartingIndex { get; private set; }
        public IList OldItems { get; private set; }
  
        public int OldStartingIndex { get; private set; }
    }
