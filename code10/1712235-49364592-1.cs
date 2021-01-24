    ViewBag.userid = Session[Declaration.sUserID];
        var userid = ViewBag.userid;
        if (userid == null)
        {
            return Redirect("signin?url=" + Server.UrlEncode(Request.Url.AbsoluteUri));
        }
        else
        {
            string ReturnUrl = Convert.ToString(Request.QueryString["url"]);
            if (!string.IsNullOrEmpty(ReturnUrl))
            {
                return Redirect(ReturnUrl);//http://localhost:55197/usermanagement
            }
            else
            {
                return RedirectToAction("DashBoard");
            }
        }
        return View();
