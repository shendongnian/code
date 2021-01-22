    /// <summary>
    /// Call with Startup property in App.xaml
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void AppStartupMainMAGI(object sender, StartupEventArgs e)
    {
        String[] arguments = Environment.GetCommandLineArgs();
   
        if (arguments.GetLength(0) > 1)
        {
            if (arguments[1].EndsWith(".magi"))
            {
                string filePathFormMainArgs = arguments[1];
                if(isFileMagiValid(filePathFormMainArgs)) 
                {
                    // Step 1 : deserialize filePathFormMainArgs
                    // Step 2 : call the view "File oepn" in the application"
                }
            }
        }
        else {
            // Call the view "welcome page application"
        }
    }
