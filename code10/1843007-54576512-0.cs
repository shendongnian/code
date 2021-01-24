    protected void Page_Load(object sender, EventArgs e)
            {
                string starOrBullet = "star-link";
                string appSet = "http://linktracker.swmed.org:8020/LinkTracker/Default.aspx?LinkID=";
                string LinkID = "2";
                string tabID = "1";
                string linkText = "linkText_Here";
                string sOutput = string.Empty;
    
                StringBuilder sbControlHtml = new StringBuilder();
    
                using (StringWriter stringWriter = new StringWriter())
                {
                    using (HtmlTextWriter htmlWriter = new HtmlTextWriter(stringWriter))
                    {
                        //Generate container div control  
                        HtmlGenericControl divControl = new HtmlGenericControl("div");
                        divControl.Attributes.Add("class", string.Format("item link-item {0}",starOrBullet));                    
    
                        //Generate link control  
                        HtmlGenericControl linkControl = new HtmlGenericControl("a");
                        linkControl.Attributes.Add("href", string.Format("{0}{1}&TabID={2}",appSet,LinkID,tabID));
                        linkControl.Attributes.Add("target", "_blank");
                        linkControl.InnerText = linkText;
    
                        //Add linkControl to container div  
                        divControl.Controls.Add(linkControl);
    
                        //Generate HTML string and dispose object   
                        divControl.RenderControl(htmlWriter);
                        sbControlHtml.Append(stringWriter.ToString());
                        divControl.Dispose();
                    }
                }
    
                sOutput = sbControlHtml.ToString();
            }
