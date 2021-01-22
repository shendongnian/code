    public class FixedCollectionEditor : CollectionEditor
    {
        bool modified;
        public FixedCollectionEditor(Type type)
            : base(type)
        { }
        public override object EditValue(System.ComponentModel.ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            value = base.EditValue(context, provider, value);
            if (modified && value != null)
            {
                value = value.GetType()
                    .GetMethod("MemberwiseClone", BindingFlags.Instance | BindingFlags.NonPublic)
                    .Invoke(value, new object[] { });
            }
            return value;
        }
        protected override CollectionForm CreateCollectionForm()
        {
            CollectionForm collectionForm = base.CreateCollectionForm();
            foreach (Control table in collectionForm.Controls)
            {
                if (!(table is TableLayoutPanel)) { continue; }
                foreach (Control grid in table.Controls)
                {
                    if (!(grid is PropertyGrid)) { continue; }
                    ((PropertyGrid)grid).PropertyValueChanged += 
                        new PropertyValueChangedEventHandler(FixedCollectionEditor_PropertyValueChanged);
                }
            }
            return collectionForm;
        }
        void FixedCollectionEditor_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            modified = true;
        }
    }
