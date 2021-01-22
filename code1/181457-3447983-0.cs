    switch (menuId)
        {
            case 0: 
                TestPanel.Controls.Add(new HyperLink { Text = "Test", NavigateUrl = "testUrl", CssClass="Sublink" });
                TestPanel.Controls.Add(new HyperLink { Text = "Test2", NavigateUrl = "testUrl2", CssClass = "Sublink" });
                break;
            case 1:
                TestPanel.Controls.Add(new HyperLink { Text = "xxx", NavigateUrl = "xxx", CssClass="Sublink" });
                TestPanel.Controls.Add(new HyperLink { Text = "xxx", NavigateUrl = "xxx", CssClass = "Sublink" });
                break;
            case 2:
                TestPanel.Controls.Add(new HyperLink { Text = "xxx", NavigateUrl = "xxx", CssClass = "Sublink" });
                TestPanel.Controls.Add(new HyperLink { Text = "xxx", NavigateUrl = "xxx", CssClass = "Sublink" });
                break;
            default:
                break;
        }
