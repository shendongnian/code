    public ActionResult AuthAprEm(string AutKn)
        {
            //The token in the email is stored in database
            var authDetails = 
                GenMethods.ExecuteStoredProc("RedeemAuthToken", 
                new List<string> { "Token" }, 
                new List<object> { AutKn }, 
                "SQL CONNECTION STRING");
            //If the token is invalid, return to relevant view for user to see
            if (authDetails.Rows.Count == 0)
            {
                return RedirectToAction("TokenUsed", "Home", new { });
            }
            else
            {
                //GET DESIRED INFORMATION FROM DATABASE QUERY, THEN REDIRECT TO DESIRED VIEW
                var username = authDetails.Rows[0]["UserName"].ToString();
                var userPwd = authDetails.Rows[0]["UserPassword"].ToString();
                if (username.ToLower().Contains("tmp_") && userPwd.ToLower().Contains("tmp_"))
                {
                    return RedirectToAction("TempCredWarn", "Home", new { });
                }
                var authRsp1 = WebAuth.UserAuth(username, userPwd, ConfigurationManager.ConnectionStrings["DbPlaceHolder"].ConnectionString.Replace("{PlcHold}", ConfigurationManager.AppSettings["HostDb"]));
                authRsp1.Staib = true;
                return RedirectToAction("CreateNewSession", authRsp1);
            }
        }
