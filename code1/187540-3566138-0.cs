        public static Control FindControl(Control parent, string id)
        {
            foreach (Control control in parent.Controls)
            {
                if (control.ID == id)
                {
                    return control;
                }
                var childResult = FindControl(control, id);
                if (childResult != null)
                {
                    return childResult;
                }
            }
            return null;
        }
