        public static Control FindControl(string controlId, Control container)
        {
            if (container.ID == controlId)
                return container;
            foreach (Control control in container.Controls)
            {
                Control c = FindControl(controlId, control);
                if (c != null)
                    return c;
            }
            return null;
        }
