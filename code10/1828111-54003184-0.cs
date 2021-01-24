    static class ConfigurationSettings
    {
        public static int LeftControl => ...
        public static int RighControl => ...
    }
    class MyClass
    {
        // MyClass uses configuration settings:
        public int LeftControl => ConfigurationSettings.LeftControl;
        public int RightControl => ConfigurationSettings.RightControl;
        ...
    }
