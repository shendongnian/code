    public class ContactOperationsFacade: IContactOperationsFacade { //<-Note interface/contract
    
        private readonly IContactRepository contactRepository;
        
        public ContactOperationsFacade(IContactRepository contactRepositor){
            this.contactRepository = contactRepository;
        }
    
        //...
    }
