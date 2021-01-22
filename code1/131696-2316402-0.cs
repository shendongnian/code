    [serializable] 
    public class Person { 
       private string fn; 
       private string ln; 
       private int age; 
       ... 
       public string FirstName { 
          get { 
             return fn; 
          } 
          set { 
             fn=value; 
          } 
       } 
       ... 
       ... 
       public Person (string firstname, string lastname, int age) { 
          this.fn=firstname; 
          ... 
       } 
    } 
