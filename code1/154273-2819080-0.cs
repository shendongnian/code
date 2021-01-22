        public string GetControlSummary(Control rootControl, int level)
        {
            string result = "";
            foreach (Control childControl in rootControl.Controls)
            {
                result += new string(' ', level * 4) + childControl.Name + " (" + childControl.GetType().Name + ")\r\n";
                result += GetControlSummary(childControl, level + 1);
            }
            return result;
        }
