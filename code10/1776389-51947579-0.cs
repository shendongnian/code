    entryRowMyNewEntrys.CollectionChanged += (s, e) =>
    {
        switch (e.Action)
        {
            case NotifyCollectionChangedAction.Add:
                MyNewEntry added = e.NewItems?.OfType<MyNewEntry>().FirstOrDefault();
                string key = "...";
                if (added != null && !dicForMyNewEntrys.ContainsKey(key))
                    dicForMyNewEntrys.Add(key, added);
                break;
            case NotifyCollectionChangedAction.Remove:
                MyNewEntry removed = e.OldItems?.OfType<MyNewEntry>().FirstOrDefault();
                key = "...";
                if (removed != null && dicForMyNewEntrys.ContainsKey(key))
                    dicForMyNewEntrys.Remove(key);
                break;
        }
    };
