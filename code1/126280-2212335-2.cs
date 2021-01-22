		MyMainForm hostInterface;
        static void Main( )
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			hostInterface = new HostInterface();
            // do some stuff to get the form ready
            // here you can optionally instance a splash screen
            MySplashScreen splash;
            hostInterface.Load += splash.Close();    // <- might not be 100% accurate
            splash = new MySplashScreen();
			Application.Run(hostInterface);
		}
