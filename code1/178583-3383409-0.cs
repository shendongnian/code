    public class Person(....)
    {
        protected string userID;
        public Person(....)
        {
          //create userID   //no, print it
          Console.WriteLine(userID);
        }
    }
    public class Staff : Person
    {
        public Staff(...)
          : base(....)         // now it is printed
        {
           this.userID = ...;  // and now it is filled
        } 
    }
