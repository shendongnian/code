    using System.Windows.Forms;
        protected delegate void Procedure();
        private void executeAfterLoadingComplete(Procedure doNext) {
            WebBrowserDocumentCompletedEventHandler handler = null;
            handler = delegate(object o, WebBrowserDocumentCompletedEventArgs e)
            {
                ie.DocumentCompleted -= handler;
                Timer timer = new Timer();
                EventHandler checker = delegate(object o1, EventArgs e1)
                {
                    if (WebBrowserReadyState.Complete == ie.ReadyState)
                    {
                        timer.Dispose();
                        doNext();
                    }
                };
                timer.Tick += checker;
                timer.Interval = 200;
                timer.Start();
            };
            ie.DocumentCompleted += handler;
        }
