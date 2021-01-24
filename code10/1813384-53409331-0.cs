    Regex regex = new Regex(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
            string[] values = commentstxt.Text.Trim().Split(' ');
    
            bool isValid = false;
    
    
            for (int i = 0; i < values.Length; i++)
            {
                
                isValid = regex.IsMatch(values[i].ToString().Trim());
    
    
                if (isValid)
                {
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "CropImage", "alert('you can not enter email id.');", true);
                    //break;
                    Response.Write("<script language='javascript'>window.alert('you can not enter email id in company profile.');window.location='addlisting.aspx';</script>");
                    break;
                }
                else
                {
                    continue;
                    
                }
    
                
            }
    
            if(!isValid)
            {
                Server.Transfer("addlistingpost.aspx", true);
            }
