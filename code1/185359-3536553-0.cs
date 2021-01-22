      protected Dictionary<String, String> _javaScriptTokens = new Dictionary<String, String>();
      public void AddJavaScriptToken(string tokenValue, string propertyName)
      {
         _javaScriptTokens.Add(propertyName, tokenValue);
      }
      protected override void OnPreRender(EventArgs e)
      {
         if (_javaScriptTokens.Count > 0)
         {
            StringBuilder sb = new StringBuilder();
            foreach (KeyValuePair<String, String> kvp in _javaScriptTokens)
            {
               sb.AppendLine(String.Format("var TOKEN_{0} = unescape('{1}');", kvp.Key, PUtilities.Escape(kvp.Value)));
            }
            ClientScript.RegisterStartupScript(this.GetType(), "PAGE_TOKENS", sb.ToString(), true);
         }
         base.OnPreRender(e);
      }
