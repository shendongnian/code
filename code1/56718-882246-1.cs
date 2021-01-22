    using System.ComponentModel;
    using System.Collections.Generic;
    using System;
    using System.Windows.Forms;
    
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            PropertyBagList list = new PropertyBagList();
            list.Columns.Add("Foo");
            list.Columns.Add("Bar");
            list.Add("abc", "def");
            list.Add("ghi", "jkl");
            list.Add("mno", "pqr");
    
            Application.Run(new Form {
                Controls = {
                    new DataGridView {
                        Dock = DockStyle.Fill,
                        DataSource = list
                    }
                }
            });
        }
    }
    class PropertyBagList : List<PropertyBag>, ITypedList
    {
        public PropertyBag Add(params string[] args)
        {
            if (args == null) throw new ArgumentNullException("args");
            if (args.Length != Columns.Count) throw new ArgumentException("args");
            PropertyBag bag = new PropertyBag();
            for (int i = 0; i < args.Length; i++)
            {
                bag[Columns[i]] = args[i];
            }
            Add(bag);
            return bag;
        }
        public PropertyBagList() { Columns = new List<string>(); }
        public List<string> Columns { get; private set; }
    
        PropertyDescriptorCollection ITypedList.GetItemProperties(PropertyDescriptor[] listAccessors)
        {
            if(listAccessors == null || listAccessors.Length == 0)
            {
                PropertyDescriptor[] props = new PropertyDescriptor[Columns.Count];
                for(int i = 0 ; i < props.Length ; i++)
                {
                    props[i] = new PropertyBagPropertyDescriptor(Columns[i]);
                }
                return new PropertyDescriptorCollection(props, true);            
            }
            throw new NotImplementedException("Relations not implemented");
        }
    
        string ITypedList.GetListName(PropertyDescriptor[] listAccessors)
        {
            return "Foo";
        }
    }
    class PropertyBagPropertyDescriptor : PropertyDescriptor
    {
        public PropertyBagPropertyDescriptor(string name) : base(name, null) { }
        public override object GetValue(object component)
        {
            return ((PropertyBag)component)[Name];
        }
        public override void SetValue(object component, object value)
        {
            ((PropertyBag)component)[Name] = (string)value;
        }
        public override void ResetValue(object component)
        {
            ((PropertyBag)component)[Name] = null;
        }
        public override bool CanResetValue(object component)
        {
            return true;
        }
        public override bool ShouldSerializeValue(object component)
        {
            return ((PropertyBag)component)[Name] != null;
        }
        public override Type PropertyType
        {
            get { return typeof(string); }
        }
        public override bool IsReadOnly
        {
            get { return false; }
        }
        public override Type ComponentType
        {
            get { return typeof(PropertyBag); }
        }
    }
    class PropertyBag
    {
        private readonly Dictionary<string, string> values
            = new Dictionary<string, string>();
        public string this[string key]
        {
            get
            {
                string value;
                values.TryGetValue(key, out value);
                return value;
            }
            set
            {
                if (value == null) values.Remove(key);
                else values[key] = value;
            }
        }
    }
