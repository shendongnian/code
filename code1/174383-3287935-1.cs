    public static class ControlUtility
    {
        public static void AddCssClass(WebControl control, string cssClass)
        {
            control.CssClass += " " + cssClass;
        }
        public static void RemoveCssClass(WebControl control, string cssClass)
        {
            control.CssClass = control.CssClass.Replace(" " + cssClass, "");
        }
    }
    ControlUtility.RemoveCssClass(lnkletter, "ln-enabled");
    ControlUtility.RemoveCssClass(lnkletter, "ln-disabled");
