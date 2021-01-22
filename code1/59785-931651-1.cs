    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Windows.Forms;
    class PropertyBagPropertyDescriptor : PropertyDescriptor {
        public PropertyBagPropertyDescriptor(string name) : base(name, null) { }
        public override object GetValue(object component) {
            return ((PropertyBag)component)[Name];
        }
        public override void SetValue(object component, object value) {
            ((PropertyBag)component)[Name] = (string)value;
        }
        public override void ResetValue(object component) {
            ((PropertyBag)component)[Name] = null;
        }
        public override bool CanResetValue(object component) {
            return true;
        }
        public override bool ShouldSerializeValue(object component)
        { // *** this controls whether it appears bold or not; you could compare
          // *** to a default value, or the last saved value...
            return ((PropertyBag)component)[Name] != null;
        }
        public override Type PropertyType {
            get { return typeof(string); }
        }
        public override bool IsReadOnly {
            get { return false; }
        }
        public override Type ComponentType {
            get { return typeof(PropertyBag); }
        }
    }
    [TypeConverter(typeof(PropertyBagConverter))]
    class PropertyBag {
        public string[] GetKeys() {
            string[] keys = new string[values.Keys.Count];
            values.Keys.CopyTo(keys, 0);
            Array.Sort(keys);
            return keys;
        }
        private readonly Dictionary<string, string> values
            = new Dictionary<string, string>();
        public string this[string key] {
            get {
                string value;
                values.TryGetValue(key, out value);
                return value;
            }
            set {
                if (value == null) values.Remove(key);
                else values[key] = value;
            }
        }
    }
    // has the job of (among other things) providing properties to the PropertyGrid
    class PropertyBagConverter : TypeConverter {
        public override bool GetPropertiesSupported(ITypeDescriptorContext context) {
            return true; // are we providing custom properties from here?
        }
        public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, System.Attribute[] attributes) {
            // get the pseudo-properties
            PropertyBag bag = (PropertyBag)value;
            string[] keys = bag.GetKeys();
            PropertyDescriptor[] props = Array.ConvertAll(
                keys, key => new PropertyBagPropertyDescriptor(key));
            return new PropertyDescriptorCollection(props, true);
        }
    }
    
    static class Program {
        [STAThread]
        static void Main() { // demo form app
            PropertyBag bag = new PropertyBag();
            bag["abc"] = "def";
            bag["ghi"] = "jkl";
            bag["mno"] = "pqr";
            Application.EnableVisualStyles();
            Application.Run(
                new Form {
                    Controls = { new PropertyGrid {
                        Dock = DockStyle.Fill,
                        SelectedObject = bag
                    }}
                });
        }
    }
