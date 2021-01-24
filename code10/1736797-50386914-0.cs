    public class ApplicationContext
    {
       private ApplicationContext(){
       }
       public User UserInfo {get;}
       
       public static ApplicationContext Current{get;}
       public static Init(User userInfo)
       {
           if(Current != null)
               throw new Exception("Context already initialized");
           
           Current = new ApplicationContext(){
               UserInfo = userInfo
           }
       }
    }
