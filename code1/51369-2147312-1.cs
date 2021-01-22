     public static Control FindAnyControl(this Page page, string controlId)
        {
            return FindControlRecursive(controlId, page.Form);
        }
        public static Control FindAnyControl(this UserControl control, string controlId)
        {
            return FindControlRecursive(controlId, control);
        }
        public static Control FindControlRecursive(string controlId, Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                Control result = FindControlRecursive(controlId, control);
                if (result != null)
                {
                    return result;
                }
            }
            return parent.FindControl(controlId);
        }
