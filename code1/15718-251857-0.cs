    public abstract class SomeBaseClass: ISomeInterface
    {
         [MyAttribute]
         abstract void MyTestMethod();
         
    
    }
    
    public SomeClass : SomeBaseClass{
    
      MyAttribute GetAttribute(){
          Type t = GetType();
          object[] attibutes = t.GetCustomAttributes(typeof(MyAttribute), false);
    
          if (attributes.Count() == 0)
                throw new Exception("could not find MyAttribute defined for " + methodBase.Name);
            return attributes[0] as MyAttribute;
      }
    
    
      ....
    }
