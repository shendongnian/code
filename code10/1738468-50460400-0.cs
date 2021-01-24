    public class MyComponent : Component
    {
        [Editor(typeof(MyUITypeEditor), typeof(UITypeEditor))]
        public string SampleProperty { get; set; }
    }
    public class MyUITypeEditor : UITypeEditor
    {
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.DropDown;
        }
        IWindowsFormsEditorService svc;
        public override object EditValue(ITypeDescriptorContext context,
            IServiceProvider provider, object value)
        {
            var list = new ListBox();
            var items = new[] { "A", "B", "C" };
            list.Items.AddRange(items);
            list.SelectionMode = SelectionMode.One;
            list.SelectedIndex = 0;
            if (items.Contains(($"{value}")))
                list.SelectedIndex = items.ToList().IndexOf($"{value}");
            list.SelectedValueChanged += List_SelectedValueChanged;
            svc = provider.GetService(typeof(IWindowsFormsEditorService))
                as IWindowsFormsEditorService;
            svc.DropDownControl(list);
            return list.SelectedItem;
        }
        private void List_SelectedValueChanged(object sender, EventArgs e)
        {
            svc.CloseDropDown();
        }
    }
