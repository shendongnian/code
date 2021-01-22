     public static Control FindAnyControl(this Page page, string controlId)
        {
            return FindControlReqursive(controlId, page.Form);
        }
        public static Control FindAnyControl(this UserControl control, string controlId)
        {
            return FindControlReqursive(controlId, control);
        }
        public static Control FindControlReqursive(string controlId, Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                Control result = FindControlReqursive(controlId, control);
                if (result != null)
                {
                    return result;
                }
            }
            return parent.FindControl(controlId);
        }
