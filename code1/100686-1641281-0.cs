    public class MyUtility
        {
            public static Control FindControl(string id, ControlCollection col)
            {
                foreach (Control c in col)
                {
                    Control child = FindControlRecursive(c, id);
                    if (child != null)
                        return child;
                }
                return null;
            }
    
            private static Control FindControlRecursive(Control root, string id)
            {
                if (root.ID != null && root.ID == id)
                    return root;
    
                foreach (Control c in root.Controls)
                {
                    Control rc = FindControlRecursive(c, id);
                    if (rc != null)
                        return rc;
                }
                return null;
            }
        }
