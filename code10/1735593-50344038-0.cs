     <body>
        @{
            string controller = "";
            string action = "";
            if (ViewContext.RouteData.Values["controller"] != null)
            {
                controller = ViewContext.RouteData.Values["controller"].ToString();
            }
            if (ViewContext.RouteData.Values["action"] != null)
            {
                action = ViewContext.RouteData.Values["action"].ToString();
            }
        }
        <div class="float-right">
                    <section id="login">
                        @Html.Partial("_LoginPartial")
                    </section>
                    <nav>
                        <ul id="menu">
                            <li>@Html.ActionLink("Home", "Index", "Home")</li>
                            @if (controller.ToLower() == "home" && action.ToLower() == "about")
                            {
                            <li>@Html.ActionLink("About", "About", "Home")</li>
                            }
                            <li>@Html.ActionLink("Contact", "Contact", "Home")</li>
                        </ul>
                    </nav>
                </div>
