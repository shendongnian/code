    /// <summary>
    /// All pages inherit this page
    /// </summary>
    public class BasePage : System.Web.UI.Page {
    
        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);
        }
    
        public bool ViewStateEnabled {
            get {
                return Page.EnableViewState;
            }
            set {
                Page.EnableViewState = value;
            }
        }
    
        public BasePage() {
            // Disable ViewState By Default
            ViewStateEnabled = false;
        }
    }
