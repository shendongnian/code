    public class MySimpleBindingStartup : IWebJobsStartup
    {
        public void Configure(IWebJobsBuilder builder)
        {
            builder.AddMySimpleBinding();
        }
    }
