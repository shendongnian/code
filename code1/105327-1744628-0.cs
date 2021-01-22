    public class SetupView
    {
        public static SetupView CreateView(DatabaseModel databaseModel, SettingsModel settingsModel, ViewUtilities viewUtilities)
        {
            var setupViewModel = new SetupViewModel(databaseModel, settingsModel, viewUtilities);
            var setupView = new SetupView();
            setupView.DataContext = setupViewModel;
            return setupView;
        }
    }
