    geWebBrowser.KmlEvent += GeWebBrowserKmlEvent;
    private void GeWebBrowserKmlEvent(object sender, GEEventArgs e)
            {
                // if it is a mouse event
                if (null != sender as IKmlMouseEvent)
                {
                    handleKmlMouseEvents((IKmlMouseEvent)sender, e.Data);
                }
                else
                {
                    MessageBox.Show(GEHelpers.GetTypeFromRcw(sender));
                }
            }
     private void handleKmlMouseEvents(IKmlMouseEvent mouseEvent, string action)
            {
                string currentTarget = mouseEvent.getCurrentTarget().getType();
    
                switch (action)
                {
                    case "mousemove":
                        {
                            DoMouseMove(mouseEvent);
                            break;
                        }
    
                    case "click":
                        {
                            DoClick(mouseEvent, currentTarget);
                            break;
                        }
                    case "mousedown":
                        {
                            DoMouseDown(mouseEvent, currentTarget);
                            break;
                        }
                    case "mouseup":
                        {
                            DoMouseUp(mouseEvent);
                            break;
                        }
                }
            }
     private void DoMouseMove(IKmlMouseEvent mouseEvent)
     {
    
     }
