        private void Application_Startup(object sender, StartupEventArgs e)
        {
            //Method 1 - Resource Dictionary
            if (e.InitParams != null)
            {
                foreach (var item in e.InitParams)
                {
                    this.Resources.Add(item.Key, item.Value);
                }
            }
            this.RootVisual = new MainPage();
        }
