    <% 
        if (User.IsInRole("AdminRole")
            Html.RenderPartial("AdminMenu"); 
        else if (User.IsInRole("Approver")
            Html.RenderPartial("ApproverMenu"); 
        else if (User.IsInRole("Editor")
            Html.RenderPartial("EditorMenu"); 
    %>
