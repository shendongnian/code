        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
            var stackPanel = new StackPanel();
            var content = new ContentPresenter
                              {
                                  Content = Content
                              };
            var userControl = new UserControlDefinedInXAML();
            userControl.Children.Add(content);
            stackPanel.Children.Add(userControl);
            Content = stackPanel;           
        }
