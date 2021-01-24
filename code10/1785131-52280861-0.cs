    using System.Collections;
    using System.ComponentModel;
    using System.Windows.Forms;
    [ProvideProperty("DisplayName", typeof(Control))]
    public class DisplayNameExtender : Component, IExtenderProvider
    {
        private Hashtable displayNameValues = new Hashtable();
        public bool CanExtend(object extendee)
        {
            return (extendee is Control && !(extendee is Form));
        }
        public string GetDisplayName(Control control)
        {
            if (displayNameValues.ContainsKey(control))
                return (string)displayNameValues[control];
            return null;
        }
        public void SetDisplayName(Control control, string value)
        {
            if (string.IsNullOrEmpty(value))
                displayNameValues.Remove(control);
            else
                displayNameValues[control] = value;
        }
    }
