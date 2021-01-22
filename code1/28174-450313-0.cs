    static class WebControlsExtensions
        {
            public static void AddCssClass(this WebControl control, string cssClass)
            {
                List<string> classes = control.CssClass.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
    
                classes.Add(cssClass);
    
                control.CssClass = classes.ToDelimitedString(" ");
            }
    
            public static void RemoveCssClass(this WebControl control, string cssClass)
            {
                List<string> classes = control.CssClass.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
    
                classes.Remove(cssClass);
    
                control.CssClass = classes.ToDelimitedString(" ");
            }
        }
    
        static class StringExtensions
        {
            public static string ToDelimitedString(this IEnumerable<string> list, string delimiter)
            {
                StringBuilder sb = new StringBuilder();
                foreach (string item in list)
                {
                    if (sb.Length > 0)
                        sb.Append(delimiter);
    
                    sb.Append(item);
                }
    
                return sb.ToString();
            }
        }
