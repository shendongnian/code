        public class HangfireTests
        {
            public HangfireTests()
            {
            }
            public void Start()
            {
                WebApp.Start<Startup>("http://localhost:8888");
                Console.WriteLine("Server started... press any key to shut down");
            RecurringJob.AddOrUpdate("systeminfo",
                () => GetTime(), Cron.Minutely);
                RecurringJob.AddOrUpdate("checktask",
                () => GetTime(), Cron.Minutely);
        }
            public static string GetTime()
            {
                var now = DateTime.Now.ToString(CultureInfo.InvariantCulture);
                Console.WriteLine(now);
                return now;
            }
            public void Stop()
            {
            }
        }
    }
