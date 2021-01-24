    @using User
    @using (Html.BeginForm("CreateUser", "User", FormMethod.Post))
    {
        @Html.EditorFor(m => m.UserName)
        
       <input type="submit" value="Submit" />
    }
    @{
      if(ViewBag.SuccessMessage != null)
      {
         <div>
             @ViewBag.SuccessMessage
         </div>
      }
    }
