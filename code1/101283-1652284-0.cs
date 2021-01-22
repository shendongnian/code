    public class TemplateImplementation : ITemplate
    {
        public void InstantiateIn(Control container)
        {
            Label label = new Label();
            label.DataBinding += Label_DataBinding;
            container.Controls.Add(label);
        }
        void Label_DataBinding(object sender, EventArgs e)
        {
            Label label = (Label)sender;
            object dataItem = DataBinder.GetDataItem(label.NamingContainer);
            string sName = /* Lookup your name using the dataitem here here */;
            label.Text = sName;
        }
    }
