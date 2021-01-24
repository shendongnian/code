       public class CustomClass {      }
       interface IConn
       {
           CustomClass CC();
       }
       public class Conn : IConn
       {
          public CustomClass CC()
          {
             return  new CustomClass();
          }
       }
