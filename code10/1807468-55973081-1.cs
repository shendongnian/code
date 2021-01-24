    [Service(IsolatedProcess = false, Exported = true, Label = "TestService")]
        public class TestService : Service
        {
    System.Threading.Timer _timer;
    
            public override IBinder OnBind(Intent intent)
            {
                return null;
            }
    
            public override void OnCreate()
            {
                base.OnCreate();
            }
    
            [return: GeneratedEnum]
            public override StartCommandResult OnStartCommand(Intent intent, [GeneratedEnum] StartCommandFlags flags, int startId)
            {
                businessLogicMethod();
    
                base.OnStartCommand(intent, flags, startId);
                return StartCommandResult.Sticky;
    
            }
    
    public void businessLogicMethod()
            {
     //My business logic in a System.Threading.Timer
    
    }
    }
