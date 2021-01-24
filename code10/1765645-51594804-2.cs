    using System;
    using System.Diagnostics;
    using System.Windows;
    using DotNetBrowser;
    using DotNetBrowser.DOM;
    using DotNetBrowser.DOM.Events;
    
    namespace WpfApplication33
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
    
                browserView.Browser.FinishLoadingFrameEvent += (s, e) =>
                {
                    if(e.IsMainFrame)
                    {
                        JSValue window = e.Browser.ExecuteJavaScriptAndReturnValue("window");
                        window.AsObject().SetProperty("CoordinatesObject", new CoordinatesObject());
    
    
                        //This code only notified that the onmousemove event was fired.
                        //It can't return the current mouse position.
                        //    DOMDocument document = browserView.Browser.GetDocument();
                        //    DOMElement documentElement = document.DocumentElement;
                        //    DOMEventHandler eventHandler = (sender, args) =>
                        //    {
                        //        Debug.WriteLine("OnMouseMove Fired");
                        //    };
                        //    documentElement.AddEventListener(DOMEventType.OnMouseMove, eventHandler, false);
                    }
                };
    
                browserView.Browser.ScriptContextCreated += (sender, args) =>
                {
                    args.Browser.ExecuteJavaScript(@"
                            document.onmousemove = getMouseXY;
                            function getMouseXY(e) {
                            CoordinatesObject.MousePosition(e.pageX, e.pageY);
                            }");
                };
                browserView.Browser.LoadURL("google.com");
            }
    
            private void button_Click(object sender, RoutedEventArgs e)
            {
                browserView.InputSimulator.SimulateMouseMoveEvent(200, 150);
            }
        }
    
        internal class CoordinatesObject
        {
            public void MousePosition(int X, int Y)
            {
                Debug.WriteLine("X=" + X + " Y=" + Y);
            }
        }
    }
