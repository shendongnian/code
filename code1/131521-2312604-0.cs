    private void DrawHelpGuide(int ID, int Type, string Name, string Description, string Version, string URL)
        {
                var lnkbtnTitle = new LinkButton();
    
                lnkbtnTitle.CssClass = "HelpGuideTitle";
                lnkbtnTitle.ToolTip = Description;
                lnkbtnTitle.Text = Name + ' ' + Version;
                lnkbtnTitle.CommandArgument = ID.ToString();
                lnkbtnTitle.Click += new EventHandler(lnkbtnTitle_Click);
                pnlHelpGuidesView.Controls.Add(lnkbtnTitle);
            }
    
        void lnkbtnTitle_Click(object sender, EventArgs e)
        {
            var ClickedButton = (LinkButton)sender;
            var id = int.Parse(ClickedButton.CommandArgument);
        } 
