    public static class SettingsUpdate
    {
        public static void Update()
        {
            try
            {
                var a = Assembly.GetExecutingAssembly();
                string appVersionString = a.GetName().Version.ToString();
                if( UserSettings.Default.internalApplicationVersion != appVersionString )
                {
                    var currentConfig = ConfigurationManager.OpenExeConfiguration( ConfigurationUserLevel.PerUserRoamingAndLocal );
                    var exeName = "MyApplication.exe";
                    var companyFolder = new DirectoryInfo( currentConfig.FilePath ).Parent.Parent.Parent;
                    FileInfo latestConfig = null;
                    foreach( var diSubDir in companyFolder.GetDirectories( "*" + exeName + "*", SearchOption.AllDirectories ) )
                    {
                        foreach( var file in diSubDir.GetFiles( "user.config", SearchOption.AllDirectories ) )
                        {
                            if( latestConfig == null || file.LastWriteTime > latestConfig.LastWriteTime )
                            {
                                latestConfig = file;
                            }
                        }
                    }
                   
                    if( latestConfig != null )
                    {
                        var lastestConfigDirectoryName = Path.GetFileName( Path.GetDirectoryName( latestConfig.FullName ) );
                        var latestVersion = new Version( lastestConfigDirectoryName );
                        var lastFramework35Version = new Version( "4.0.4605.25401" );
                        if( latestVersion <= lastFramework35Version )
                        {
                            var destinationFile = Path.GetDirectoryName( Path.GetDirectoryName( currentConfig.FilePath ) );
                            destinationFile = Path.Combine( destinationFile, lastestConfigDirectoryName );
                            if( !Directory.Exists( destinationFile ) )
                            {
                                Directory.CreateDirectory( destinationFile );
                            }
                            destinationFile = Path.Combine( destinationFile, latestConfig.Name );
                            File.Copy( latestConfig.FullName, destinationFile );
                        }
                    }
                    Properties.Settings.Default.Upgrade();
                    UserSettings.Default.Upgrade();
                    UserSettings.Default.internalApplicationVersion = appVersionString;
                    UserSettings.Default.Save();
                }
            }
            catch( Exception ex )
            {
                LogManager.WriteExceptionReport( ex );
            }
        }
    }
