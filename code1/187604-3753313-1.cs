    public class FixedCollectionEditor : CollectionEditor
    {        
        bool modified;
        public FixedCollectionEditor(Type type)
            : base(type)
        { }
        public override object EditValue(System.ComponentModel.ITypeDescriptorContext context, IServiceProvider provider, object value)
        {            
            value = base.EditValue(context, provider, value);
            if (value != null && modified)
            {
                value = value.GetType()
                    .GetMethod("MemberwiseClone", BindingFlags.Instance | BindingFlags.NonPublic)
                    .Invoke(value, new object[] { });                
            }
            modified = false;
            return value;
        }
        protected override CollectionForm CreateCollectionForm()
        {
            CollectionForm collectionForm = base.CreateCollectionForm();
            foreach (Control table in collectionForm.Controls)
            {
                if (!(table is TableLayoutPanel)) { continue; }
                foreach (Control c1 in table.Controls)
                {
                    if (c1 is PropertyGrid)
                    {
                        PropertyGrid propertyGrid = (PropertyGrid)c1;
                        propertyGrid.PropertyValueChanged += new PropertyValueChangedEventHandler(GotModifiedHandler);
                    }
                    if (c1 is TableLayoutPanel)
                    {
                        foreach (Control c2 in c1.Controls)
                        {
                            if (!(c2 is Button)) { continue; }
                            Button button = (Button)c2;
                            if (button.Name == "addButton" || button.Name == "removeButton")
                            {
                                button.Click += new EventHandler(GotModifiedHandler);
                                if (button.ContextMenuStrip != null)
                                {
                                    button.ContextMenuStrip.ItemClicked += new ToolStripItemClickedEventHandler(GotModifiedHandler);
                                }
                            }
                        }
                    }
                }
            }
            return collectionForm;
        }
        void GotModifiedHandler(object sender, EventArgs e)
        {
            modified = true;
        }
    }
