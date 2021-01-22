    using System.Windows;
    using System.Windows.Forms;
    
    namespace Common.Helpers
    {
        public static class WindowHelpers
         {
            public static Screen CurrentScreen(this Window window)
             {
                 return Screen.FromPoint(new System.Drawing.Point((int)window.Top,(int)window.Left));
             }
         }
    }
