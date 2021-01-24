    ViewBag.userid = Session[Declaration.sUserID];
        var userid = ViewBag.userid;
        if (userid == null)
        {
            Response.Redirect("signin?url=" + Server.UrlEncode(Request.Url.AbsoluteUri));
            return;  // ADD THIS
        }
        else
        {
            string ReturnUrl = Convert.ToString(Request.QueryString["url"]);
            if (!string.IsNullOrEmpty(ReturnUrl))
            {
                Response.Redirect(ReturnUrl);//http://localhost:55197/usermanagement
                return;  // ADD THIS
            }
            else
            {
                return RedirectToAction("DashBoard");
            }
        }
        return View();
