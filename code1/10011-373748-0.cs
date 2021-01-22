        public static void Run( Type type )
        {
            // Register WMI stuff
            var installArgs = new[]
                                       {
                                           string.Format( "//logfile={0}", @"c:\Temp\sample.InstallLog" ), "//LogToConsole=false", "//ShowCallStack",
                                           type.Assembly.Location,
                                       };
            
            ManagedInstallerClass.InstallHelper( installArgs );
        }
