    public static string readControlText(Control varControl)
    {
        if (varControl.InvokeRequired)
        {
            string res = "";
            var action = new Action<Control>(c => res = c.Text);
            varControl.Invoke(action, varControl);
            return res;
        }
        string varText = varControl.Text;
        return varText;
    }
