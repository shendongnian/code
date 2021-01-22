    <% 
        if (User.IsInRole("AdminRole")
            Html.RenderPartial("AdminMenu"); 
        if (User.IsInRole("Approver")
            Html.RenderPartial("ApproverMenu"); 
        if (User.IsInRole("Editor")
            Html.RenderPartial("EditorMenu"); 
    %>
