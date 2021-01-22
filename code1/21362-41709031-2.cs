    System.ArgumentNullException: Key cannot be null.
    Parameter name: key
       at System.Collections.Specialized.ListDictionary.get_Item(Object key)
       at System.Collections.Specialized.HybridDictionary.get_Item(Object key)
       at System.ComponentModel.PropertyChangedEventManager.RemoveListener(INotifyPropertyChanged source, String propertyName, IWeakEventListener listener, EventHandler`1 handler)
       at System.ComponentModel.PropertyChangedEventManager.RemoveHandler(INotifyPropertyChanged source, EventHandler`1 handler, String propertyName)
       at MS.Internal.Data.PropertyPathWorker.ReplaceItem(Int32 k, Object newO, Object parent)
       at MS.Internal.Data.PropertyPathWorker.UpdateSourceValueState(Int32 k, ICollectionView collectionView, Object newValue, Boolean isASubPropertyChange)
