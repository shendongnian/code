    <% 
       if (item.FieldType == "TextBox")
       {%>
             <%=Html.TextBox(item.Field, **item.Value**, new { tabindex = item.SortOrder })%>
             <%}
                if (item.FieldType == "CheckBox")
                {%>
                  <%=Html.CheckBox(item.Field, **item.Value**, new { tabindex = item.SortOrder })%>
                <%}
