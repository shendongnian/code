    // enumerate your list of property names (perhaps from a file)
    var settings = new List<string>(); 
    settings.Add("MyOne"); 
    settings.Add("MyTwo"); 
    settings.Add("MyThree");
    var settingMap = new Dictionary<string, int>(); 
    int value = 0; 
    foreach (var name in settings) 
    {
        try
        {
            // try to parse the setting as an integer
            if (Int32.TryParse((string)Properties.Settings.Default[name], out value))
            {
                // add map property name to value if successful
                settingMap.Add(name, value);
            }
            else
            {
                // alert if we were unable to parse the setting
                Console.WriteLine(String.Format("The settings property \"{0}\" is not a valid type!", name));
            }
         }
         catch (SettingsPropertyNotFoundException ex)
         {
             // alert if the setting name could not be found
             Console.WriteLine(ex.Message);
         }
    }
