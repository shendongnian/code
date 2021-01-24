    namespace Tools
    {
        public class Library
        {
            public General general;
            public Library
            {
                 general = New General();
            }
            public class General
            {
    
                public Form frmMain;
    
    
                public void updateText(Control ctrl, string content)
                {
                    if (ctrl != null && (ctrl is Label || ctrl is TextBox))
                    {
                        if (ctrl.InvokeRequired)
                        {
                            ctrl.Invoke(new MethodInvoker(delegate
                            {
                                ctrl.Text = content;
                            }));
                        }
                        else
                        {
                            ctrl.Text = content;
                        }
                    }
                }
    
    
            }
    
            public class Settings
            {
    
                public Form frmMain;
    
    
                public void someMethod()
                {
    
                }
    
    
            }
    
    }
