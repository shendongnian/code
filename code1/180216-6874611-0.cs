        private void Test()
        {
             List<Control> allTextboxes = GetAllControls(this);
        }
        private List<Control> GetAllControls(Control container, List<Control> list)
        {
            foreach (Control c in container.Controls)
            {
                if (c is TextBox) list.Add(c);
                if (c.Controls.Count > 0)
                    list = GetAllControls(c, list);
            }
            return list;
        }
        private List<Control> GetAllControls(Control container)
        {
            return GetAllControls(container, new List<Control>());
        }
