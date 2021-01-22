    public class SingletonClass{
         private static SingletonClass _instance;
         private SingletonClass(){}
         public static Instance
         {
             get
             {
                 if(_instance == null){
                    _instance = new SingletonClass();
                 }
             }
         }
    }
