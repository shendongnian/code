        private Control content;
        // add the content
        this.MainContent.Controls.Add(content);
        // if this is not a post back
        if (!this.IsPostBack)
        {
            // set to true;
            this.Expanded = true;
        }
  
