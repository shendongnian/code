    //creating a template field, where CopiledBindableTemplateBuilder is the ITemplate
    //and its InstantiateIn = @__BuildControl__control9
    @__ctrl.ItemTemplate = new System.Web.UI.CompiledBindableTemplateBuilder(
        new System.Web.UI.BuildTemplateMethod(this.@__BuildControl__control9),
        new System.Web.UI.ExtractTemplateValuesMethod(this.@__ExtractValues__control9));
    //and @__BuildControl__control9 calling @__BuildControlButton1
    private global::System.Web.UI.WebControls.Button @__BuildControlButton1()
    {
        global::System.Web.UI.WebControls.Button @__ctrl;
    
        @__ctrl = new global::System.Web.UI.WebControls.Button();
        this.Button1 = @__ctrl;
        @__ctrl.ApplyStyleSheetSkin(this);
        @__ctrl.ID = "Button1"; //<-- here it gets an ID
        @__ctrl.Text = "Button";
        return @__ctrl;
    }
