    namespace GlobalKeyPress
    {
        public class GlobalKeyPress
        {
    		public static void KeyPressFilter(object sender, System.Windows.Forms.KeyPressEventArgs e)
    		{
				if((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != '.')
					e.Handled = true;
    		}
        }
    }
