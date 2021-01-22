    public class MyApplicationContext : ObjectContext, IMyApplicationContext {   
        public MyApplicationContext() : base("name=myApplicationEntities", "myApplicationEntities")  
        {
      base.ContextOptions.LazyLoadingEnabled = true;
            m_Customers = CreateObjectSet<Customer>();
            m_Accounts = CreateObjectSet<Account>();
        }
    
     private ObjectSet<Customer> m_Customers;
     public IQueryable<Customer> Customers {
            get { return m_Customers; }
        }
     private ObjectSet<Account> m_Accounts;
     public IQueryable<Account> Accounts {
            get { return m_Accounts; }
        }
    
     public Account CreateAccount(Customer customer) {
      var account m_Accounts.CreateObject();
      account.Customer = customer;
      return account;
     }
     public Customer CreateCustomer() {
      return m_Customers.CreateCustomer();
     }
     public void AddAccount(Account account) {
      m_Accounts.AddObject(account);
     }
     public void AddCustomer(Customer customer) {
      m_Customers.AddCustomer(customer);
     }
    }
    
    public class Account {
        public int Balance {get;set;}
        virtual public Customer{get;set;}
    }
        
    public class Customer {
        public string Name {get;set;}
        virtual public List<Account> Accounts{get;set;}
    }
