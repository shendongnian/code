    void Handle_ChildAdded(object sender, ChildChangedEventArgs e)
    {
        if (e.DatabaseError != null)
        {
            Debug.LogError(e.DatabaseError.Message);
            return;
        }
        // Do something with the data in args.Snapshot
        if (e.Snapshot.Value != null)
        {
            var dict = e.Snapshot.Value as Dictionary<string, object>;
            if (dict != null)
            {
                Debug.Log(dict);
                Global.offers.Add(dict);
                hasHaded = true;
            }
        }
    }
