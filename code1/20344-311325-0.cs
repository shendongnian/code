       foreach (string key in Request.Form.Keys)
       {
            if (key.StartsWith("Email."))
            {
               ...Process this key...
            }
       }
