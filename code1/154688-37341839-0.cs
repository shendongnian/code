    public class singleton
    {
      //Name that will be used as key for Session object
      private const string SESSION_SINGLETON = "SINGLETON";
      //Variables to store the data (used to be individual
      // session key/value pairs)
      string lastName = "";
      string firstName = "";
      public string LastName
      {
        get
        {
          return lastName;
        }
        set
        {
          lastName = value;
        }
      }
      public string FirstName
      {
        get
        {
          return firstName;
        }
        set
        {
          firstName = value;
        }
      }
      //Private constructor so cannot create an instance
      // without using the correct method.  This is 
      // this is critical to properly implementing
      // as a singleton object, objects of this
      // class cannot be created from outside this
      // class
      private singleton()
      {
      }
      // Create as a static method so this can be called using
      // just the class name (no object instance is required).
      // It simplifies other code because it will always return
      // the single instance of this class, either newly created
      // or from the session
      public static singleton GetCurrentSingleton()
      {
        singleton oSingleton;
        if (null == System.Web.HttpContext.Current.Session[SESSION_SINGLETON])
        {
          //No current session object exists, use private constructor to 
          // create an instance, place it into the session
          oSingleton = new singleton();
          System.Web.HttpContext.Current.Session[SESSION_SINGLETON] = oSingleton;
        }
        else
        {
          //Retrieve the already instance that was already created
          oSingleton = (singleton)System.Web.HttpContext.Current.Session[SESSION_SINGLETON];
        }
        //Return the single instance of this class that was stored in the session
        return oSingleton;
      }
    }
