        [TestFixture]
        public class LoginTests
        {
            private TestSuiteInstrumentation instrument = TestInstrumentation.CurrentInstrumentation;
            private Activity CurrentActivity;
    
            [SetUp]
            public void SetUp()
            {
                Instrumentation.ActivityMonitor monitor = instrument.AddMonitor($"{instrument.TargetContext.PackageName}." + nameof(Login), null, false);
    
                Intent intent = new Intent();
                intent.AddFlags(ActivityFlags.NewTask);
                intent.SetClassName(instrument.TargetContext, $"{instrument.TargetContext.PackageName}." + nameof(Login));
    
                Task.Run(() => instrument.StartActivitySync(intent)).GetAwaiter();
    
                Activity currentActivity = instrument.WaitForMonitor(monitor);
    
            }
    
            [Test]
            public void LoginTest()
            {
                // Verify your activity is not null 
                Assert.NotNull(CurrentActivity);
                
                // Convert CurrentActivity to your Activity
                Login login = CurrentActivity as Login;
    
               
                // Verify your views are not null, finding views in your Activity
                Assert.NotNull(login);
                Assert.NotNull(login.FindViewById<EditText>(Resource.Id.etLoginUsername));
                Assert.NotNull(login.FindViewById<EditText>(Resource.Id.etLoginPassword));
    
                
                instrument.RunOnMainSync(() => {
                    // Here you can run your UI methods or properties for Views, example
                    login.FindViewById<EditText>(Resource.Id.etLoginUsername).Text = "hello";
                    login.FindViewById<EditText>(Resource.Id.etLoginPassword).Text = "world";
                });
                // Here will be your assertions
            }
        } 
