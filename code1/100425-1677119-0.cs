    public static class ControlExtensions
    {
        public static Control FindControl(this Control control, string id, bool Recursive)
        {
            var result = control.FindControl(id);
            if (!Recursive) return result;
            if (result == null)
            {
                foreach (Control child in control.Controls)
                {
                    result = child.FindControl(id, true);
                    if (result != null) return result;
                }
            }
            return null;
        }
    }
