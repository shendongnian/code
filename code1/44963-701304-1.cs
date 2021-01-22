    private void AddTemplates()
    {
        TemplateField templateField = new TemplateField();
        templateField.HeaderText = entity.ChangeHistoryColumn;
        templateField.ItemTemplate = new GridViewColumnTemplate();
        GridViewMain.Columns.Add(templateField);
    }
    
    public class GridViewColumnTemplate : ITemplate
    {
        public GridViewColumnTemplate() { }
    
        public void InstantiateIn(Control container)
        {
            Label label = new Label();
            label.DataBinding += delegate(object sender, EventArgs e)
            {
                GridViewRow row = (GridViewRow)label.NamingContainer;
    
                int headerID = (int)DataBinder.Eval(row.DataItem, "HeaderID");
                ((Label)sender).Text = headerID.ToString();
            };
    
            container.Controls.Add(label);
        }
    }
