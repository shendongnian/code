    protected void txtCountItem_Init(object sender, EventArgs e) 
    {
        ASPxTextBox textBox = sender as ASPxTextBox;
        GridViewDataItemTemplateContainer container = textBox.NamingContainer as GridViewDataItemTemplateContainer;
    
        textBox.JSProperties["cpHFKey"] = String.Format("{0}_txtCountItem_{1}", container.Grid.ClientID, container.KeyValue);
    
        textBox.ClientIDMode = ClientIDMode.Static;
        // other stuff
    }
