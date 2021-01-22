     protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string result = "result = ";
                foreach (Control tmpControl in Page.Controls)
                {
                    Type tmpType = tmpControl.GetType();
                    if (tmpControl is SiteMaster)
                    {
                        foreach (Control SiteMasterControlItem in tmpControl.Controls)
                        {
                            if (SiteMasterControlItem is System.Web.UI.HtmlControls.HtmlForm)
                            {
                                int i = 0;
                                for( i =0;i < SiteMasterControlItem.Controls.Count; i++)
                                {
                                    Type tmpType2 = SiteMasterControlItem.Controls[i].GetType();
                                }
                            }
                            
                        }
                    }
                }
                Response.Write(result);
            }
            catch(Exception ex)
            {
                Response.Write("error = " + ex.StackTrace);
            }
        }
