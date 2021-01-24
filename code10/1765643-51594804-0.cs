    using System;
    using System.Diagnostics;
    using System.Windows.Forms;
    using DotNetBrowser;
    using DotNetBrowser.DOM;
    using DotNetBrowser.DOM.Events;
    using DotNetBrowser.WinForms;
    
    namespace WindowsFormsApplication43
    {
        public partial class Form1 : Form
        {
            private readonly BrowserView browserView;
    
            public Form1()
            {
                InitializeComponent();
    
                Width = 900;
                Height = 600;
    
                browserView = new WinFormsBrowserView();
                Controls.Add((Control) browserView);
    
                browserView.Browser.FinishLoadingFrameEvent += (s, e) =>
                {
                    if (e.IsMainFrame)
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
    
            private void button1_Click(object sender, EventArgs e)
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
