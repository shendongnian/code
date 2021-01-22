    public class UserInstantiatedClass
    {
       public int UserSetField1;
       public int UserSetField2;
       public int UserSetField3;
       public int UserSetField4;
       public string UserSpecifiedClassName;
    }
    
    public static class MyProgram
    {
       public static void Main(string [] args) 
       {
          // gather user input, place into variables named 
          // numInstances, className, field1, field2, field3, field4
          List<UserInstantiatedClass> instances = new List< UserInstantiatedClass>();
          UserInstantiatedClass current = null;
          for(int i=1; i<=numInstances; i++)
          {
             current = new UserInstantiatedClass();
             current.UserSpecifiedClassName = className + i.ToString(); // adds the number 1, 2, 3, etc. to the class name specified
             current.UserSetField1 = field1;
             current.UserSetField2 = field2;
             current.UserSetField3 = field3;
             current.UserSetField4 = field4;
             instances.Add(current);
          }
          // after this loop, the instances list contains the number of instances of the class UserInstantiatedClass specified by the numInstances variable.  
       }
    }
