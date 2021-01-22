    protected void Page_PreRender(object sender, EventArgs e)
        {
            HtmlLink link = null;
            LiteralControl script = null;
            foreach (Control c in Header.Controls)
            {
                //StyleSheet add version
                if (c is HtmlLink)
                {
                    link = c as HtmlLink;
                    if (link.Href.EndsWith(".css", StringComparison.InvariantCultureIgnoreCase))
                    {
                        link.Href += string.Format("?v={0}", ConfigurationManager.AppSettings["agVersion"]);
                    }
                }
                //Js add version
                if (c is LiteralControl)
                {
                    script = c as LiteralControl;
                    if (script.Text.Contains(".js"))
                    {
                        var foundIndexes = new List<int>();
                        for (int i = script.Text.IndexOf(".js\""); i > -1; i = script.Text.IndexOf(".js\"", i + 1))
                        {
                            
                            foundIndexes.Add(i);
                        }
                        for (int i = foundIndexes.Count - 1; i >= 0; i--)
                        {
                            
                            script.Text = script.Text.Insert(foundIndexes[i] + 3, string.Format("?v={0}", ConfigurationManager.AppSettings["agVersion"]));
                        }
                    }
                }
            }
        }
