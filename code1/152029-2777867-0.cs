    public class TestDesignProperty : UITypeEditor
    {
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.DropDown;
        }
        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            var edSvc = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
            ListBox lb = new ListBox();
            foreach(var type in this.GetType().Assembly.GetTypes())
            {
                lb.Items.Add(type);
            }
            if (value != null)
            {
                lb.SelectedItem = value;
            }
            edSvc.DropDownControl(lb);
            value = (Type)lb.SelectedItem;
            return value;
        }
    }
