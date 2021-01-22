    public class YourLinks
    {
    
       // You could do it by overloading the constructor...
       // Again not sure how you determine what links should be displayed...
       // If you had consistent types you could make your constructor internal
       // and then create a YourLinkBuilder see below...
       public YourLinks(User user, Region region)
       {
          
       }
    
       public YourLinks(City city)
       {
    
       }
    
       // Databind to this method...
       public IEnumerable<string> GetLinks()
       {
          // return your links...
       }
    
    }
    
    public class YourLinkBuilder
    {
       public static YourLinks BuildPowerUserLinks()
       {
          return new YourLinks(new PowerUser(), new Region("Washington"));
       }
       public static YourLinks BuildVisitorLinks()
       {
          return new YourLinks(new VisitorUser(), new Region("Empty"));
       }
    }
