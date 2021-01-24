    public class MyCollectionEditor<T> : CollectionEditor
    {
        public MyCollectionEditor() : base(typeof(T)) { }
        public override object EditValue(ITypeDescriptorContext context, 
            IServiceProvider provider, object value)
        {
            return base.EditValue(context, provider, value);
        }
        protected override CollectionForm CreateCollectionForm()
        {
            var f = base.CreateCollectionForm();
            var propertyBrowser = f.Controls.Find("propertyBrowser", true)
                .OfType<PropertyGrid>().FirstOrDefault();
            var listbox = f.Controls.Find("listbox", true)
               .OfType<ListBox>().FirstOrDefault();
            if (propertyBrowser != null)
                propertyBrowser.SelectedObjectsChanged += (sender, e) =>
                {
                    var o = listbox.SelectedItem;
                    if (o != null)
                        propertyBrowser.SelectedObject =
                            o.GetType().GetProperty("Value").GetValue(o);
                };
            return f;
        }
    }
