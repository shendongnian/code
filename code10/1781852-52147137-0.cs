    class ModelClass:INotifyCollectionChanged
    {
        public List<Element> eList;// call OnCollectionChanged() when you set/add/remove...the list).
    
        public void MethodA()
        {
            doSomething();
        }
    
        #region INotifyCollectionChanged Members
     
        protected void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            if (CollectionChanged != null)
                CollectionChanged(this, e);
        }
     
        public event NotifyCollectionChangedEventHandler CollectionChanged;
     
        #endregion
    
    }
