    public class SetupView
    {
        public static SetupView CreateView(SetupViewModel model)
        {
            var setupView = new SetupView(); { DataContext = model };
            return setupView;
        }
    }
