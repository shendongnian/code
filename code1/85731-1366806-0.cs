    public class MyUserControlBase : UserControl {
        private Panel mainPanel;
        protected Panel MainPanel {
            get { return this.mainPanel; }
        }
    
        public MyUserControlBase() {
            this.mainPanel = new Panel();
            this.Controls.Add( this.mainPanel );
            this.CreateMainPanelContent();
        }
    
        protected virtual void CreateMainPanelContent() {
            // create default content
            Label lblInfo = new Label();
            lblInfo.Text = "This is common user control.";
            this.MainPanel.Controls.Add( lblInfo );
        }
    }
    
    public class MyWeatherUserControl : MyUserControlBase {
        protected override void CreateMainPanelContent() {
            // the base method is not called,
            // because I want create custom content
    
            Image imgInfo = new Image();
            imgInfo.ImageUrl = "http://some_weather_providing_server.com/current_weather_in_new_york.gif";
            this.MainPanel.Controls.Add ( imgInfo );
        }
    }
    
    public class MyExtendedWeatherUserControl : MyWeatherUserControl {
        protected override void CreateMainPanelContent() {
            // the base method is called,
            // because I want only extend content
            base.CoreateMainPanelContent();
    
            HyperLink lnkSomewhere = new Hyperlink();
            lnkSomewhere.NavigationUrl = "http://somewhere.com";
            this.MainPanel.Controls.Add ( lnkSomewhere );
        }
    }
