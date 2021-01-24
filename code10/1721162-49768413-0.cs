    internal class FinalTest : IHostedService, IDisposable
    {
        
        private Timer aTimer;
        public static List<Grocery> List;
        private AppDbContext db;
        // variable  to test that timer really works
        public static int test2;
       
        public FinalTest( AppDbContext _db )
        {
            db = _db;
        }
        //This method runs at the start of the application once only as FinalTest was set as Singleton in services
        public Task StartAsync(CancellationToken cancellationToken)
        {
            test2 = 1;
            aTimer =new Timer(CheckDBEvents, null , TimeSpan.Zero , TimeSpan.FromSeconds(10) );
            return Task.CompletedTask;
        }
        //Method runs every TimeSpan.FromSeconds(10)
        private void CheckDBEvents(object state)
        {
            
            var users = from u in db.Grocery where u.basic == true select u;
            List = users.ToList();
            //increase test2 To see changes in the real world
            test2++;
        }
        //--------shutdown operations---------//
        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
        public void Dispose()
        {
            aTimer?.Dispose();
        }
        
    }
