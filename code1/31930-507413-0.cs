    [Serializable]
    public class AccessPermission{
     public boolean None{get;set;}
     public boolean Read{get;set;}
     public boolean Write{get;set;}
     public boolean Full{get;set;}
    
     public AccessPermission(AccessLevels level){
      None = false;
      Read = false;
      Write = false;
      Full = false;
    
      switch(level){
      case AccessLevels.None:
       break;
      case AccessLevels.Read:
       Read = true;
       break;
      case AccessLevels.Write:
       Write = true;
       break;
      case AccessLevels.Full:
       Read = true;
       Write = true;
       Full = true;
       break;
      }
     }
    } 
