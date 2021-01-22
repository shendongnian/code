    delegate string StringInvoker();
        string GetControlText()
        {
            if (control.InvokeRequired)
            {
                string controltext = (string)control.Invoke(new StringInvoker(GetControlText));
                return(controltext);
            }
            else
            {
                return(control.Text);
            }
        }
