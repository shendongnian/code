    if (!HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    //FormsAuthentication.RedirectToLoginPage();
                    Response.Redirect("~/Login.aspx");
                }
