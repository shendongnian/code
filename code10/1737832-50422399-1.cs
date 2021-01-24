    public class DemoClass
    {
         private StatusClass _mStatus = new StatusClass();
    
         public DemoClass()
         {
              _mStatus.PropertyChanged = (sender, args) => { this.Refresh(); }
         }
    }
