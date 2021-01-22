    void Remove(MyItem item, IList<MyItem> list)
    {
        item.IsRemoved = true;
    
        Task.Factory.StartNew(() =>
            {
                Task.Delay(ANIMATION_LENGTH_MS);
                Dispatcher.Invoke(new Action(() => list.Remove(item)));
            });
    }
