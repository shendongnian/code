    using System;
    using System.Resources;
    using System.Reflection;
    
    public class MyClass
    {
      enum SomeEnum {Small,Large};
      private ResourceManager _resources = new ResourceManager("MyClass.myResources",
                              System.Reflection.Assembly.GetExecutingAssembly());    
    	
      public string EnumDescription(Enum enumerator)
      {		
        string rk = String.Format("{0}.{1}",enumerator.GetType(),enumerator);
        string localizedDescription = _resources.GetString(rk);
    		
        if (localizedDescription == null)
           {
           // A localized string was not found so you can either just return
           // the enums value - most likely readable and a good fallback.
           return enumerator.ToString();
           // Or you can return the full resourceKey which will be helpful when
           // editing the resource files(e.g. MyClass+SomeEnum.Small) 
           // return resourceKey;
           }
        else
           return localizedDescription;
    	}
    
    
      void SomeRoutine()
      {
        // Looks in resource file for a string matching the key
        // "MyClass+SomeEnum.Large"
        string s1 = EnumDescription(SomeEnum.Large);       
      }
    }
