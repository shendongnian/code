    delegate string StringInvoker();
        string GetControlText()
        {
            if (control.InvokeRequired)
            {
                string controltext = (string)Invoke(new StringInvoker(GetControlText));
                return(controltext);
            }
            else
            {
                return(control.Text);
            }
        }
