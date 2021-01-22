    public static class ExtensionMethods
    {
        public static Control FindControl(this Control root, string name)
        {
            foreach (Control c in root.Controls)
            {
                // Check this control
                if (c.Name == name) return c;
                // Check this controls subcontrols
                Control tmp = c.FindControl(name);
                if (tmp != null) return tmp;
            }
            return null;
        }
    }
