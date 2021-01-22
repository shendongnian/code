    public class MyCustomServerCtrl
    {
    
       ...
    
       public MyCustomServerCtrl Clone()
       {
          return MemberwiseClone() as MyCustomServerCtrl;
       }
    
    }
