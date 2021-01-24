    public class Company
    {
        public  Company ( )
        {
          // ef needs this constructor even though it is never called by 
         // my code in the application. EF needs it to set up the contexts
           
          // Failure to have it will result in a 
          //  No suitable constructor found for entity type 'Company'. exception
        }
                
        public Company ( string _companyName , ......)
        {
             // some code
        }
    }
