    public class Global : System.Web.HttpApplication
    {
        private static readonly TimeSpan UpdateEngineTimerFrequency = TimeSpan.FromMinutes(10);
        private Timer UpdateEngineTimer { get; set; }
        private void MyTimerAction(object state)
        {
            // do engine work here - call other servers, bake cookies, etc.
        }
        protected void Application_Start(object sender, EventArgs e)
        {
            this.UpdateEngineTimer = new Timer(MyTimerAction,
                                               null, /* or whatever state object you need to pass */
                                               UpdateEngineTimerFrequency,
                                               UpdateEngineTimerFrequency);
        }
        protected void Application_End(object sender, EventArgs e)
        {
            this.UpdateEngineTimer.Dispose();
        }
    }
