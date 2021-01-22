        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
            var grid = new Grid();
            var content = new ContentPresenter
                              {
                                  Content = Content
                              };
            var userControl = new UserControlDefinedInXAML();
            userControl.aStackPanel.Children.Add(content);
            grid.Children.Add(userControl);
            Content = grid;           
        }
