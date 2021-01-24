	public void LoadDocuments()
	{
		var documents = myIdbConnection.GetAll<Document>();			
		Documents = new ObservableCollection<Document>(documents);
        Documents.CollectionChanged += Documents_CollectionChanged;
    }
