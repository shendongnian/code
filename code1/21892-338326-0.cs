    // assembly 1 - Base Class which contains the contractpublic class BaseEntity 
      {  
          public string MyName  // I changed to a property
          {    
              get { return ToString().Split(',')[0]; }
          }
      }
    // assembly 2 - contains plugins based on the Base Class
     public class BlueEntity : BaseEntity {}
     public class YellowEntity : BaseEntity {}
     public class GreenEntity : BaseEntity {}
     // main console app
      List<BaseEntity> plugins = Factory.GetMePluginList();
      foreach (BaseEntity be in plugins) 
         {  Console.WriteLine(be.MyName);}
