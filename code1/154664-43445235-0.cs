    <% Html.RenderPartial("MyPartialView", Model.AnotherClass,new ViewDataDictionary(){
    TemplateInfo = new TemplateInfo(){
    HtmlFieldPrefix = "AnotherClass"
    }
    }); %>
