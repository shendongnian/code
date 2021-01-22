    using System.Windows.Forms;
        namespace YourNamespace{
            public static class WindowsFormExtensions {
                public static void PutOnTop(this Form form) {
                    form.Show();
                    form.Activate();
                }// END PutOnTop()       
            }// END class
        }// END namespace
