    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            SetLanguageDictionary();
        }
        private void SetLanguageDictionary()
        {
            switch (Thread.CurrentThread.CurrentCulture.ToString())
            {
                case "nl-NL":
                    MyProject.Language.Resources.Culture = new System.Globalization.CultureInfo("nl-NL");
                    break;
                case "en-GB":
                    MyProject.Language.Resources.Culture = new System.Globalization.CultureInfo("en-GB");
                    break;
                default://default english because there can be so many different system language, we rather fallback on english in this case.
                    MyProject.Language.Resources.Culture = new System.Globalization.CultureInfo("en-GB");
                    break;
            }
           
        }
    }
