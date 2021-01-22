    public class Global : HttpApplication {
        void Application_Start(object sender, EventArgs e) {
            var application = Context.ApplicationInstance;
            FluentScheduler.TaskManager.UnobservedTaskException +=
                (FluentScheduler.Model.TaskExceptionInformation i, UnhandledExceptionEventArgs a) =>
                    Elmah.ErrorSignal.Get(application).Raise(i.Task.Exception);
        }
	}
