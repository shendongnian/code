    public static class Utils
    {
        public static void HideKeyboard(Activity context)
        {
            var imm = (InputMethodManager)context.GetSystemService(Context.InputMethodService);
            int sdk = (int)Build.VERSION.SdkInt;
    
            if (sdk < 11)
            {
                imm.HideSoftInputFromWindow(context.Window.CurrentFocus.WindowToken, 0);
            }
            else
            {
               imm.HideSoftInputFromWindow(context.CurrentFocus.WindowToken, HideSoftInputFlags.NotAlways);
            }
        }
    }
