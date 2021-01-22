    [Ajax.AjaxMethod]
    public string GetDDL(int itemId, int lng)
    {
        PanelID = Panel1.ID;
        DropDownList rubricDDL = new DropDownList();
        rubricDDL.ID = "Fashionable_Catheter";
        rubricDDL.DataTextField = "title";
        rubricDDL.DataValueField = "id";
        rubricDDL.DataSource = %LINQ STUFF%;
        rubricDDL.DataBind();
        panelID.Controls.Add(rubricDDL);
        StringBuilder sb = new StringBuilder();
        HtmlTextWriter htw = new HtmlTextWriter(new StringWriter(sb));
        panelID.RenderControl(htw);
        return sb.ToString(); 
    }
