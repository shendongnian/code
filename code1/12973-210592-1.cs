        private Control findControl(string id)
        {
            Control c = this;
            while (c != null)
            {
                if (c.ID == id)
                    break;
                else
                    c = c.Parent;
            }
            return c as Control;
        }
