    protected void Page_Load(object sender, EventArgs e)
    {
        System.Web.UI.HtmlControls.HtmlGenericControl createDiv =
        new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");      
        createDiv.ID = "createDiv";
        createDiv.Style.Add(HtmlTextWriterStyle.BackgroundColor, "Yellow");
        createDiv.Style.Add(HtmlTextWriterStyle.Color, "Red");
        createDiv.Style.Add(HtmlTextWriterStyle.Height, "100px");
        createDiv.Style.Add(HtmlTextWriterStyle.Width, "400px");
        createDiv.InnerHtml = " I'm a div, from code behind ";
        this.Controls.Add(createDiv);
    }
