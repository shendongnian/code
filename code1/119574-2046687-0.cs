     <% foreach (var category in ViewData.Model)
           { %>
    
            <li>
                <%=Html.ActionLink(category.CategoryName, new string { action = "List", category = category.CategoryName })%>
            </li>
        <% } %>
