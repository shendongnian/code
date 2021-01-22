    using System;
    using System.Text;
    using System.Windows;
    using System.Windows.Controls; //are you missing this namespace?
    namespace YourNameSpaceHere
    {
            public class Messaging
            {
                Messaging()
                {
                    MessageBox.Show(MainWindow.message_);
                }
            }
    }
