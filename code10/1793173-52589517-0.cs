    public void UnPublishDatabases(IReadOnlyCollection<IPublishedDatabase> sqlDatabases) {
        var listener = new UnpublishDatabaseListener();
        Action<IPublishedDatabase> handler = delegate { };
        handler = db => {
            OnDatabaseUnpublished(db); 
            //unsubscribe
            listner.DatabaseUnpublished -= handler;
        };
        //subscribe
        listener.DatabaseUnpublished += handler;
    
        _publishController.Unpublish(sqlDatabases, listener);
        //...
    }
