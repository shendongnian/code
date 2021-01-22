    class ToolTipHelper
    {
        private static readonly Dictionary<string, ToolTip> tooltips = new Dictionary<string, ToolTip>();
        public static ToolTip GetControlToolTip(string controlName)
        {
            <same as above still>
        }
        public static ToolTip GetControlToolTip(Control control)
        {
            return GetControlToolTip(control.Name);
        }
        public static void SetToolTip(Control control, string text)
        {
            ToolTip tt = GetControlToolTip(control);
            tt.SetToolTip(control, text);
        }
    }
