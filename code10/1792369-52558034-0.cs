    myObservable.CollectionChanged += (sender, e) =>
    {
        if (e.Action == NotifyCollectionChangedAction.Add)
        {
            foreach (TimeLineChannel c in e.NewItems)
            {
                TimeLine.Controls.Add(c);
            }
        }
    };
