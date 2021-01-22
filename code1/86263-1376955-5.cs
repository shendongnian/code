    public static class GlobalNotifier
    {
        public static event VoidEventHandler EnvironmentChanged;
        public static void OnEnvironmentChanged()
        {
            if (EnvironmentChanged != null)
            {
                EnvironmentChanged();
            }
        }
     }
