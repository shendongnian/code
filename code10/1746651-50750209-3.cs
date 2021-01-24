    public void Save()
    {
        myIdbConnection.Update(Documents.Where(x=>!x.IsNew));
        myIdbConnection.Insert(Documents.Where(x=>x.IsNew));
    }
