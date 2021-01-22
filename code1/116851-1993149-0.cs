    using System.Windows;
    using System.Windows.Markup;
    using System.Globalization;
    
    ...
    void App_Startup(object sender, StartupEventArgs e)
    {
        FrameworkElement.LanguageProperty.OverrideMetadata(  
            typeof(FrameworkElement),  
            new FrameworkPropertyMetadata(XmlLanguage.GetLanguage(CultureInfo.CurrentCulture.IetfLanguageTag)));
    }
