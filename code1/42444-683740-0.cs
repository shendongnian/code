    using System;
    using System.Windows.Forms;
    
    namespace MyNamespace
    {
        public class MainEntry
        {
            private static bool mIsConsole = false;
    
            private MainEntry() { }
    
            public static bool IsConsoleApp
            {
                get { return mIsConsole; }
            }
    
            public static int DoMain(string[] args, bool isConsole)
            {
                mIsConsole = isConsole;
                try
                {
                    // do whatever - main program execution
                    return 0; // "Good" DOS return code
                }
                catch (Exception ex)
                {
                    if (MainEntry.IsConsoleApp)
                    {
                        Console.Error.WriteLine(ex.Message);
                    }
                    else
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    return 1; // "Bad" DOS return code indicating failure
                }
            }
        }
    }
