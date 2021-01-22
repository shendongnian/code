    if (Request.HttpMethod.ToLower() == "post" && Request.Form.Count > 0)
        {
            if (!string.IsNullOrEmpty(Request.Form["feeds"]) || !string.IsNullOrEmpty(Request.Form["txtcomment"]))
            {
                if (!string.IsNullOrEmpty(Request["property"]) || !string.IsNullOrEmpty(Request["project"]))
                {
                    if (IsUserLoggedIn||(!IsUserLoggedIn && !string.IsNullOrEmpty(Request["txtName"]) && !string.IsNullOrEmpty(Request["txtContact"]) && !string.IsNullOrEmpty(Request["txtEmail"])))
                    {
                        if (Request.Form["feeds"] != "[Select your option]")
                        {
                            Mail(Request.Form["feeds"], Request.Form["txtcomment"]);
                        }
                        else
                        {
                            Common.ClientMessage("Select the Option and Retry to Submit the feeds.", CommonConsts.AlertType.info);
                        }
                    }
                    else
                    {
                        Common.ClientMessage("Unregistered user must fill their name and Contact Details!", CommonConsts.AlertType.info);
                    }
                }
            }
        }
