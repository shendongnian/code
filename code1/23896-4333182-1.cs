    public partial class App : Application  
    {  
         public App()  
         {             
         }  
     
         protected override void OnStartup(StartupEventArgs e)  
         {  
             Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("de-DE"); ;  
             Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("de-DE"); ;  
     
              FrameworkElement.LanguageProperty.OverrideMetadata(  
                  typeof(FrameworkElement),  
                  new FrameworkPropertyMetadata(  
                      XmlLanguage.GetLanguage(CultureInfo.CurrentCulture.IetfLanguageTag)));  
              base.OnStartup(e);  
        }  
    } 
