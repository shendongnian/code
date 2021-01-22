    <% Html.Telerik().Grid(Model)
            .Name("Grid")
            .Columns(columns => 
            {
                columns.Template(c => {
                %>
                    <span title="<%= c.FieldName %>"><%= c.FieldName.Elipsis(50) %></span>
                <%
                });
            })
            .Render();
     %>
