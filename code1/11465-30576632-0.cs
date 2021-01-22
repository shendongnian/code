    public static class MyExtensionMethods
    {
        public static void SetAppIcon(this Form form)
        {
            form.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
        }
    }
