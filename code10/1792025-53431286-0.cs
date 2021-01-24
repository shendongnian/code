    public class V1vm : ViewModelBase
    {
      //...
      
      public MyUCvm RefToUCvm { get; set; }
      public bool MyParam
      {
         get { return MyUCvm?.MyParam ?? false; }
         set
         {
             if (MyUCvm != null)
             {
                  MyUCvm.MyParam = value;
                  NotifyPropertyChanged("MyParam");
             }
          }
       }
    }
