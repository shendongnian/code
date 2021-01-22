    public class Customer()
    {
        prop name,etc,etc;
        public List<IPolicyTerm> Policies{get;set;}//I use public getters and setters throughout but you need to choose what level of encapsulation you want
        private Account customerAccount{get;set}        
        public Customer()
        {
            //ctor
            customerAccount = doDbCall;
            Policies = doDbCall;
        }
        public decimal GetCurrentPolicyCost()
        {
            decimal cost = 0;
            foreach(var policy in Policies)
            {
                if(policy.DueDate < DateTime.Now){
                cost += policy.GetCost(); //for example but you can call whatever is defined at the interface level
                }
            }
            return cost;
        }
        public bool HasEnoughFunds()
        {
            return customerAccount.Balance >= GetCurrentPolicyCost();
        }
        //keeping Account hidden in Person as Person has a reference to Account. 
        //By doing so there is type coupling between the two classes 
        //BUT you can still modify Policies away from Person
        private class Account
        {
           //should only contain properties and I assume only one 'Account' per person
        }
    }
    public interface IPolicyTerm
    {
         object Id{get;set}
         DateTime DueDate {get;set;}
         decimal GetCost();
    }
    ///now we can have polymorphic Policies i.e. the cost of one can be calculated differently based on policy
    public class LifeCoverPolicy : IPolicyTerm
    {
         
         public object Id;
         public DateTime DueDate{get;set;}         
         public decimal GetCost()
         {
              return 10;
         }
    }
