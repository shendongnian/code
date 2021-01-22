        private bool getDesignMode()
        {
            IDesignerHost host;
            if (Site != null)
            {
                host = Site.GetService(typeof(IDesignerHost)) as IDesignerHost;
                if (host != null)
                {
                    if (host.RootComponent.Site.DesignMode) MessageBox.Show("Design Mode");
                    else MessageBox.Show("Runtime Mode");
                    return host.RootComponent.Site.DesignMode;
                }
            }
            MessageBox.Show("Runtime Mode");
            return false;
        }
