    using TestForm1.Properties;
    
    //... namespace/class stuff here
    
    Settings.Default.Test = "Hello World!";
    Settings.Default.Save();
    String test = Settings.Default.Test;
