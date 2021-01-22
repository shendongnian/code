        Point mouseLocation;
        private void ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HtmlElement elem = webBrowser.Document.GetElementFromPoint(mouseLocation);
            //From here you would do what ever it is you need for your element in the browser
        }
        private void webContextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            //This just gets you the specific mouse position for the given element
            mouseLocation = webBrowser.PointToClient(MousePosition);
        }
