    using System;
    using System.Windows.Forms;
    namespace WinFormTest
    {
        public partial class MainForm : Form
        {
            public void PerformAction(Action<MainForm> action)
            {
                if (InvokeRequired)
                    Invoke(action,this);
                else
                    action(this);
            }
            public static void PerformActionOnMainForm(Action<MainForm> action)
            {
                var form = ActiveForm as MainForm;
                if ( form!= null)
                    form.PerformAction(action);
            }
        }
    }
