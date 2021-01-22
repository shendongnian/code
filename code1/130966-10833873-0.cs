    private void MyControl_Load(object sender, EventArgs e)
            {
                if (this.Site != null)
                {
                    htmldoc = (HtmlDocument)this.Site.GetService(typeof(HtmlDocument));
                 
                }
    
           
            }
