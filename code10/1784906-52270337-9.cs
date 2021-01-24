    using Gecko;
    using Gecko.DOM;
    using System.Windows;
    using System.Windows.Forms.Integration;
    using System.Linq;    
    namespace GeckoWpf {
        public partial class MainWindow : Window {
            public MainWindow() {
                InitializeComponent();
                Gecko.Xpcom.Initialize("Firefox");
            }    
            void browser_DocumentCompleted(object sender, System.EventArgs e) {
                 //unsubscribe
                _browser.DocumentCompleted -= browser_DocumentCompleted;
                GeckoElement rt = _browser.Document.CreateElement("div");
                rt.SetAttribute("id", "blocker");
                rt.SetAttribute
                (
                "style",
                "position: fixed;"
                + "top: 0px;"
                + "left: 0px;"
                + "width: 100%;"
                + "height: 100%;"
                + "opacity: 0.0;"
                + "background-color: #111;"
                + "z-index: 9000;"
                + "overflow: auto;"
                );
                _browser.Document.Body.AppendChild(rt);
            }    
            WindowsFormsHost _host = new WindowsFormsHost();
            GeckoWebBrowser _browser = new GeckoWebBrowser();    
            private void Window_Loaded(object sender, RoutedEventArgs e) {
                _browser.DocumentCompleted += browser_DocumentCompleted;
                _host.Child = _browser;
                GridWeb.Children.Add(_host);    
                _browser.Navigate("https://www.google.com/");
            }
        }
    }
