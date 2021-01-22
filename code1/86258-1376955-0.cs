    public static class GlobalNotifier
    {
        public static event VoidEventHandler EnvrionmentChanged;
        public static void OnEnvrionmentChanged()
        {
            if (EnvrionmentChanged != null)
            {
                EnvrionmentChanged();
            }
        }
     }
