    string CharResult = "";
            object[] UserParameters = { UserName, Password };
            int Result = OwnerAccountBO.validateLogin(UserParameters);
            if (Result > 0)
            {
                HttpContext.Current.Session["OwnerAccountID"] = Result;
                CharResult += Convert.ToString(Result);
            }
            else
            {
                CharResult += "false";
            }
            return CharResult;
