    public class Document
    {
    	static bool IsNewInitializer { get; set; } = false;
    
    	int Id { get; set; }
    	string DocumentName { get; set; }
    	bool IsNew { get; set; } = IsNewInitializer; // This field is not in the database
    }
    
    public void LoadDocuments()
    {
    	Document.IsNewInitializer = false;
    	var documents = myIdbConnection.GetAll<Document>();
    	Documents = new ObservableCollection<Document>(documents);
    	Document.IsNewInitializer = true;
    }
    public void Save()
    {
    	myIdbConnection.Update(Documents.Where(x => !x.IsNew));
    	myIdbConnection.Insert(Documents.Where(x => x.IsNew));
    	foreach (var d in Documents.Where(x => x.IsNew))
    	{
    		d.IsNew = false;
    	}
    }
