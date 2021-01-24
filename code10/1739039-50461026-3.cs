    public class Factory
    {
      public static object GetAnimal(string objectName)
      {
        if(objectName == "Dob")
         return new Dog();
        else(objectName == "xyz")
         return new xyz(); 
      } 
    }
