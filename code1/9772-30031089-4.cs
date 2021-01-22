    public class ApplicationContainer : ReleaseContainer<Application>
    {
        public ApplicationContainer()
            : base(new Application(), ActionOnExcel)
        {
        }
        private static void ActionOnExcel(Application application)
        {
            application.Show(); // extension method. want to make sure the app is visible.
            application.Quit();
            Marshal.FinalReleaseComObject(application);
        }
    }
