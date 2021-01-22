    class Utility
        {
            private static StringBuilder sbListControls;
     
            public static StringBuilder GetVisualTreeInfo(Visual element)
            {
                if (element == null)
                {
                    throw new ArgumentNullException(String.Format("Element {0} is null !", element.ToString()));
                }
     
                sbListControls = new StringBuilder();
     
                GetControlsList(element, 0);
     
                return sbListControls;
            }
     
            private static void GetControlsList(Visual control, int level)
            {
                const int indent = 4;
                int ChildNumber = VisualTreeHelper.GetChildrenCount(control);
     
                for (int i = 0; i <= ChildNumber - 1; i++)
                {
                    Visual v = (Visual)VisualTreeHelper.GetChild(control, i);
     
                    sbListControls.Append(new string(' ', level * indent));
                    sbListControls.Append(v.GetType());
                    sbListControls.Append(Environment.NewLine);
     
                    if (VisualTreeHelper.GetChildrenCount(v) > 0)
                    {
                        GetControlsList(v, level + 1);
                    }
                }
            }
        } 
