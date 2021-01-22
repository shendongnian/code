    // event handler for when a document (or frame) has completed its download
    Timer m_pageHasntChangedTimer = null;
    private void webBrowser_DocumentCompleted( object sender, WebBrowserDocumentCompletedEventArgs e ) {
        // dynamic pages will often be loaded in parts e.g. multiple frames
        // need to check the page has remained static for a while before safely saying it is 'loaded'
        // use a timer to do this
        // destroy the old timer if it exists
        if ( m_pageHasntChangedTimer != null ) {
            m_pageHasntChangedTimer.Dispose();
        }
        // create a new timer which calls the 'OnWebpageReallyLoaded' method after 200ms
        // if additional frame or content is downloads in the meantime, this timer will be destroyed
        // and the process repeated
        m_pageHasntChangedTimer = new Timer();
        EventHandler checker = delegate( object o1, EventArgs e1 ) {
            // only if the page has been stable for 200ms already
            // check the official browser state flag, (euphemistically called) 'Ready'
            // and call our 'OnWebpageReallyLoaded' method
            if ( WebBrowserReadyState.Complete == webBrowser.ReadyState ) {
                m_pageHasntChangedTimer.Dispose();
                OnWebpageReallyLoaded();
            }
        };
        m_pageHasntChangedTimer.Tick += checker;
        m_pageHasntChangedTimer.Interval = 200;
        m_pageHasntChangedTimer.Start();
    }
 
    OnWebpageReallyLoaded() {
        /* place your harvester code here */
    }
