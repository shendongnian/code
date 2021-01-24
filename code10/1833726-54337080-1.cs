        [Activity(Label = "TestConfiguration")]
        public class TestConfiguration : Xunit.Runners.UI.RunnerActivity
        {
            //public static Context Context { get; set; }
    
            protected override void OnCreate(Bundle bundle)
            {
                // tests can be inside the main assembly
                AddTestAssembly(Assembly.GetExecutingAssembly());
                AddExecutionAssembly(typeof(ExtensibilityPointFactory).Assembly);
                // or in any reference assemblies	
                //this.AutoStart = true;
                base.OnCreate(bundle);
                //Context = this;
            }
        }
