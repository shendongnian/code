    public class CollectionEditorBase : CollectionEditor
    {
        protected PropertyGrid ownerGrid;
        public CollectionEditorBase(Type type) : base(type) { }
        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            PropertyInfo ownerGridProperty = provider.GetType().GetProperty("OwnerGrid", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
            ownerGrid = (PropertyGrid)ownerGridProperty.GetValue(provider);
            return base.EditValue(context, provider, value);
        }
        protected override CollectionForm CreateCollectionForm()
        {
            CollectionForm cf = base.CreateCollectionForm();
            cf.FormClosing += delegate(object sender, FormClosingEventArgs e)
            {
                ownerGrid.Refresh();
                if (CollectionEditorClosed != null)
                    CollectionEditorClosed(this, value);
            };
            return cf;
        }
    }
