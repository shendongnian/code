    protected override void OnItemsChanged(NotifyCollectionChangedEventArgs e)
    {
        switch (e.Action)
        {
            case NotifyCollectionChangedAction.Add:
            case NotifyCollectionChangedAction.Move:
                break;
    
            case NotifyCollectionChangedAction.Remove:
            case NotifyCollectionChangedAction.Reset:
                if ((this.SelectedItem == null) || this.IsSelectedContainerHookedUp)
                {
                    break;
                }
                this.SelectFirstItem();
                return;
    
            case NotifyCollectionChangedAction.Replace:
            {
                object selectedItem = this.SelectedItem;
                if ((selectedItem == null) || !selectedItem.Equals(e.OldItems[0]))
                {
                    break;
                }
                this.ChangeSelection(selectedItem, this._selectedContainer, false);
                return;
            }
            default:
                throw new NotSupportedException(SR.Get("UnexpectedCollectionChangeAction", new object[] { e.Action }));
        }
    }
