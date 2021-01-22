        protected override void OnPreRender(EventArgs e) 
           {
                bool linkIncluded = false;
                foreach (Control c in Page.Header.Controls)
                {
                    if (c.ID == "GridStyle")
                    {
                        linkIncluded = true;
                    }
                }
                if (!linkIncluded)
                {
                    HtmlGenericControl csslink = new HtmlGenericControl("link");
                    csslink.ID = "GridStyle";
                    csslink.Attributes.Add("href", Page.ClientScript.GetWebResourceUrl(this.GetType(), "CustomControls.Styles.GridStyles.css"));
                    csslink.Attributes.Add("type", "text/css");
                    csslink.Attributes.Add("rel", "stylesheet");
                    Page.Header.Controls.Add(csslink);
                }
            }
