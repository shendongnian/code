    public void Update(Connector newConnector)
    {
        if (newConnector.Password == "")
        {
            var oldConnector = _db.ConnectorsTable
                .Where(x => x.ID == newConnector.ID)
                .Single(); //Grabbing the old connectors password
            newConnector.Password = oldConnector.Password;
        }
        
        //Update the old entity with values from the new entity:
        _db.Entry(oldConnector).CurrentValues.SetValues(newConnector);
        _db.SaveChanges();
    }
