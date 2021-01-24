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
    
                XPathResult xpathResult = _browser.Document.EvaluateXPath("//div/input");
                var foundNodes = xpathResult.GetNodes();
                foreach (var node in foundNodes) {
                    GeckoInputElement txtbox = new GeckoInputElement(node.DomObject);
                    txtbox.Value = "Mona Lisa"; //add the search term
                }    
                (_browser.Document.GetElementsByTagName("form").First() as GeckoFormElement).submit();
            }
  
            WindowsFormsHost _host = new WindowsFormsHost();
            GeckoWebBrowser _browser = new GeckoWebBrowser();    
            private void Window_Loaded(object sender, RoutedEventArgs e) {
                _browser.DocumentCompleted += browser_DocumentCompleted;
                _host.Child = _browser;    GridWeb.Children.Add(_host);    
                _browser.Navigate("https://www.google.com/");
            }
        }
    }
