        private void Application_Startup(object sender, StartupEventArgs e)
        {
            string ControlID = "ControlID";
            if (e.InitParams.ContainsKey(ControlID))
            {
                switch (e.InitParams[ControlID])
                {
                    case "RegionControl":
                        this.RootVisual = new RegionControl();
                        break;
                    case "SessionControl":
                        this.RootVisual = new SessionControl();
                        break;
                    default:
                        break;
                }
            }
        }
