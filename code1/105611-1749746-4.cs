    <% 
        Html.RenderPartialIfInRole("AdminMenu", "AdminRole"); 
        Html.RenderPartialIfInRole("ApproverMenu", "Approver"); 
        Html.RenderPartialIfInRole("EditorMenu", "Editor"); 
    %>
