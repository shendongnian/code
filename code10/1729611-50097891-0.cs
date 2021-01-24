        @{
            var actionURL = Url.Action("Action", "Controller", 
                                       FormMethod.Post, Request.Url.Scheme)  
                            + Request.Url.PathAndQuery;
        }
        @using (Html.BeginForm("Action", "Controller", FormMethod.Post, 
                                                           new { @action = actionURL }))
        {
    <input type="text" name="username">
    <input type="text" name="password">
    <button  type="submit"class="btn-login"></button>
        }//Then use Request.Form[0] with the id to get the user name and password in the controller action.
