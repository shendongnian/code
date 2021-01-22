    protected void Button1_Click(object sender, EventArgs e)
       
     {
            string allowedExtensions = ".mp4,.pdf,.m4v,.gif,.jpg,.png,.swf,.css,.htm,.html,.txt";
            // edit this list to allow file types - do not allow sensitive file types like .cs or .config
            string fileName = "Images/apple.jpg";
            string filePath = "";
            //if (Request.QueryString["file"] != null) fileName = Request.QueryString["file"].ToString();
            //if (Request.QueryString["path"] != null) filePath = Request.QueryString["path"].ToString();
            if (fileName != "" && fileName.IndexOf(".") > 0)
            {
                bool extensionAllowed = false;
                // get file extension
                string fileExtension = fileName.Substring(fileName.LastIndexOf('.'), fileName.Length - fileName.LastIndexOf('.'));
                // check that we are allowed to download this file extension
                string[] extensions = allowedExtensions.Split(',');
                for (int a = 0; a < extensions.Length; a++)
                {
                    if (extensions[a] == fileExtension)
                    {
                        extensionAllowed = true;
                        break;
                    }
                }
                if (extensionAllowed)
                {
                    // check to see that the file exists 
                    if (File.Exists(Server.MapPath(filePath + '/' + fileName)))
                    {
                        // for iphones and ipads, this script can cause problems - especially when trying to view videos, so we will redirect to file if on iphone/ipad
                       // if (Request.UserAgent.ToLower().Contains("iphone") || Request.UserAgent.ToLower().Contains("ipad")) { Response.Redirect(filePath + '/' + fileName); }
                        Response.Clear();
                        Response.AddHeader("content-disposition", "attachment;filename=" + fileName);
                        Response.WriteFile(Server.MapPath(filePath + '/' + fileName));
                        Response.End();
                    }
                    else
                    {
                        litMessage.Text = "File could not be found";
                    }
                }
                else
                {
                    litMessage.Text = "File extension is not allowed";
                }
            }
            else
            {
                litMessage.Text = "Error - no file to download";
            }
        }
