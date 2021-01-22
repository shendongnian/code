    using System;`
    using System.Windows;
    String applicationName = String.Empty;
    //one way
    applicationName = AppDomain.CurrentDomain.FriendlyName.Split('.')[0];
     //other way
    applicationName = Application.ResourceAssembly.GetName().Name;
   
