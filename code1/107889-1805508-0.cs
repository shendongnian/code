    <%
    for (int i = 0; i < Model.Count; i++)
    {
        var name = "formItems[" + i + "].Field";
        var htmlAttributes = new Dictionary<string, object>
                                 {
                                     {"tabindex", Model[i].SortOrder},
                                     {"class", Model[i].ClientSideValidation}
                                 };
    %>
        <div> <%=Html.Encode(Model[i].DisplayValue)%> 
        <%=Html.TextBox(name, Model[i].DefaultValue, htmlAttributes)%> 
        <%= Html.ValidationMessage(Model[i].Field) %>
        </div>
        
    <% } %>
