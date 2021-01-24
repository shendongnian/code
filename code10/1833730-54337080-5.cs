     //#define TEST // Uncomment this to start UnitTestig
     . . .
     [ /* Your ActivityAttributes */ ]
     public class YourLauncherActivity : Activity {
        
          protected override void OnCreate(Bundle savedInstanceState)
          {
               base.OnCreate(savedInstanceState);
        #if (DEBUG && TEST)
               // Your TestConfiguration.cs Activity
               Intent iTestConfiguration = new Intent(this, typeof(TestConfiguration));
               StartActivity(iTestConfiguration);
        #endif
        #if !TEST
               // Run your normal Activity here, like Login, etc...
        #endif
                }
        	}
        
        ...
