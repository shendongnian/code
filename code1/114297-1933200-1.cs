    public static class Global
    {
        private static Form1 myForm = new Form1();
        public static bool Show()
        {
            myForm.Show();
        }
        public static bool Hide()
        {
            myForm.Close();
        }
    }
