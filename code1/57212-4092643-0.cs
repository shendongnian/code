      protected void Page_Load(object sender, EventArgs e)
        {        
            HtmlGenericControl js = new HtmlGenericControl("script");
            js.Attributes["type"] = "text/javascript";
            js.Attributes["src"] = yol.ScriptYol("jquery-1.3.2.min.js");
            this.Page.Header.Controls.Add(js);
            
        }
