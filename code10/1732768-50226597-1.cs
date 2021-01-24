     filterContext.Result =
                new RedirectToRouteResult(
                       new RouteValueDictionary
                            {
                                { "controller", "ControllerName" },
                                { "action", "Action" }
                            });
