    class statushandler
    {
        [...]
        public static void status_msg(string c_msg)
        {
            [...]
            MyUserInterface.Instance.f_status.Text = c_msg; // You have instance of yout form here
            [...]
        }
    }
