    protected override void CreateChildControls()
    {
    base.CreateChildControls();
    
    var container = new System.Web.UI.HtmlControls.HtmlGenericControl("div");
    container.Attributes.Add("id","SelectionPanel");
    
    TextBox tb = new TextBox();
    container.Controls.Add(tb);
    
    this.Controls.Add(container);
    
    }
