        // Executes when the user navigates to this page.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (NavigationContext.QueryString.ContainsKey("Param"))
            {
                paramText.Text = NavigationContext.QueryString["Param"];
            }
        }
