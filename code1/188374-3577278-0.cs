internal IList Items
{
    get
    {
        return this._items;
    }
    set
    {
        if (this._items != value)
        {
            INotifyCollectionChanged source = this._items as INotifyCollectionChanged;
            if ((this._items != this.Host.View) && (source != null))
            {
                CollectionChangedEventManager.RemoveListener(source, this);
            }
            this._items = value;
            source = this._items as INotifyCollectionChanged;
            if ((this._items != this.Host.View) && (source != null))
            {
                CollectionChangedEventManager.AddListener(source, this);
            }
        }
    }
}
