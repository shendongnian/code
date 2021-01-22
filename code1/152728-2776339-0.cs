    [ActiveRecord("companies", 
      DiscriminatorColumn="type", 
      DiscriminatorType="String", 
      DiscriminatorValue="NA")]
    public abstract class Company : ActiveRecordBase<Company>, ICompany {
        [PrimaryKey]
        private virtual int Id { get; set; }
    
        [Property]
        public virtual String Name { get; set; }
    }
    
    [ActiveRecord(DiscriminatorValue="firm")]
    public class Firm : Company {
        [Property]
        public virtual string Description { get; set; }
    }
    
    [ActiveRecord(DiscriminatorValue="client")]
    public class Client : Company {
        [Property]
        public virtual int ChargeRate { get; set; } 
    }
    
    var allClients = ActiveRecordMediator<Client>.FindAll();
    var allCompanies = ActiveRecordMediator<Company>.FindAll(); // Gets all Companies (Firms and Clients). Same as Company.FindAll();
