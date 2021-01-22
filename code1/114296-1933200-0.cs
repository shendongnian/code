    public static class Global
    {
        private static frmLoading loading= new frmLoading();
        public static bool Show()
        {
            loading.Show();
        }
        public static bool Hide()
        {
            loading.Close();
        }
    }
