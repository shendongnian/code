       public class ExampleController : Controller{
               public static userName;
               
                public void Action1(){//do stuff}
                public void Action2(){//do stuff}
                public void AssignUserName(string username){
                     userName = username;
                           
                }
               public string GetName(){ return userName;}
       }
