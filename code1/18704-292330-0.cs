    public static class ControlExtensions
    {
        /// <summary>
        /// recursive control search (extension method)
        /// </summary>
        public static Control FindControl(this Control control, string Id, ref Control found)
        {
            if (control.ID == Id)
            {
                found = control;
            }
            else
            {
                if (control.FindControl(Id) != null)
                {
                    found = control.FindControl(Id);
                    return found;
                }
                else
                {
                    foreach (Control c in control.Controls)
                    {
                        if (found == null)
                            c.FindControl(Id, ref found);
                        else
                            break;
                    }
                }
            }
            return found;
        }
    }
