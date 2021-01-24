    System.Collections.ObjectModel.ObservableCollection<object> list = new System.Collections.ObjectModel.ObservableCollection<object>();
    private void RemoveStuff()
    {
        var i = list.Count - 1;
        for (; i <= 0; i--)
        {
            // some checks here to make sure this is the time you really want to remove
            list.Remove(i);
        }
    
    }
