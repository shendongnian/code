    public class User{
      public string SupervisorId  {get;set;}
      public string UserId {get;set;}
      public string UserName   {get;set;}
      public int Level {get {  return GetRank(SupervisorId  ) ; } } 
      private int GetRank(string userId){
         if(string.IsNullOrEmpty(userId)){
             //Bad case, probably want to use a very large number
             return -1;
         }
         int level = 0;
         switch(userId){
            case "CEO":
               level  = 0;
               break;
             //insert others here
         }
      }
    }
