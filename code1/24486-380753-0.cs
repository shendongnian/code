    public class ClientDataLogic
    {
        private DataContext _db = new DataContext();
    
        public Client GetClient(int id) 
        { 
            return _db.Clients.SingleOrDefault(c => c.Id == id); 
        }
        public void SaveClient(Client c) 
        { 
            if (ChangeSetOnlyIncludesClient(c))
                _db.SubmitChanges(); 
        }
    }
