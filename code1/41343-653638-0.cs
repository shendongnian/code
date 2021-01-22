    public class SystemTest
    { 
       public TestMethod(string testString)
       {
          if(testString == "blue")
          {
             RunA();
          }
          else if(testString == "red")
          {
             RunB();
          }
          else if(testString == "orange")
          {
             RunA();
          }
          else if(testString == "pink")
          {
             RunB();
          }
       }
    
       protected event Action RunA;
       protected event Action RunB;       
    }
