    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Windows.Forms;
    class Person
    {
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public override string ToString() {
            return Name;
        }
    }
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Person fred = new Person();
            fred.Name = "Fred";
            fred.DateOfBirth = DateTime.Today.AddYears(-23);
            Person wilma = new Person();
            wilma.Name = "Wilma";
            wilma.DateOfBirth = DateTime.Today.AddYears(-20);
            ShowUnknownObject(fred, "Single object");
            List<Person> list = new List<Person>();
            list.Add(fred);
            list.Add(wilma);
            ShowUnknownObject(list, "List");
        }
        static void ShowUnknownObject(object obj, string caption)
        {
            using(Form form = new Form())
            using (PropertyGrid grid = new PropertyGrid())
            {
                form.Text = caption;
                grid.Dock = DockStyle.Fill;
                form.Controls.Add(grid);
                grid.SelectedObject = ListWrapper.Wrap(obj);
                Application.Run(form);
            }
        }
    }
    [TypeConverter(typeof(ListWrapperConverter))]
    public class ListWrapper
    {
        public static object Wrap(object obj)
        {
            IListSource ls = obj as IListSource;
            if (ls != null) obj = ls.GetList(); // list expansions
            IList list = obj as IList;
            return list == null ? obj : new ListWrapper(list);
        }
        private readonly IList list;
        private ListWrapper(IList list)
        {
            if (list == null) throw new ArgumentNullException("list");
            this.list = list;
        }
        internal class ListWrapperConverter : TypeConverter
        {
            public override bool GetPropertiesSupported(ITypeDescriptorContext context)
            {
                return true;
            }
            public override PropertyDescriptorCollection GetProperties(
                ITypeDescriptorContext context, object value, Attribute[] attributes) {
                return new PropertyDescriptorCollection(
                    new PropertyDescriptor[] { new ListWrapperDescriptor(value as ListWrapper) });
            }
        }
        internal class ListWrapperDescriptor : PropertyDescriptor {
            private readonly ListWrapper wrapper;
            internal ListWrapperDescriptor(ListWrapper wrapper) : base("Wrapper", null)
            {
                if (wrapper == null) throw new ArgumentNullException("wrapper");
                this.wrapper = wrapper;
            }
            public override bool ShouldSerializeValue(object component) { return false; }
            public override void ResetValue(object component) {
                throw new NotSupportedException();
            }
            public override bool CanResetValue(object component) { return false; }
            public override bool IsReadOnly {get {return true;}}
            public override void SetValue(object component, object value) {
                throw new NotSupportedException();
            }
            public override object GetValue(object component) {
                return ((ListWrapper)component).list;
            }
            public override Type ComponentType {
                get { return typeof(ListWrapper); }
            }
            public override Type PropertyType {
                get { return wrapper.list.GetType(); }
            }
            public override string DisplayName {
                get {
                    IList list = wrapper.list;
                    if (list.Count == 0) return "Empty list";
                    return "List of " + list.Count
                        + " " + list[0].GetType().Name;
                }
            }
        }
    }
