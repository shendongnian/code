    public class UserEngine {
    public ICollectionView UserdataCollectionView { get; set; }
    public UserEngine()    { 'constructor
        UserdataCollectionView = CollectionViewSource.GetDefaultView(UserDataGridCollection );
    }
    public void addnewLinetoOC(){
        // after you add a new entry into your observable collection 
        UserdataCollectionView .Refresh();
    }
    }
