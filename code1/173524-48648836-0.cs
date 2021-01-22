    var webBrowser = this.WebBrowser.GetType().InvokeMember("AxIWebBrowser2",
                                                            BindingFlags.Instance |
                                                            BindingFlags.NonPublic |
                                                            BindingFlags.GetProperty,
                                                            null,
                                                            this.WebBrowser,
                                                            new Object[] { });
    
    webBrowser.GetType().InvokeMember("RegisterAsDropTarget",
                                      BindingFlags.Instance |
                                      BindingFlags.SetProperty,
                                      null,
                                      webBrowser,
                                      new Object[] { false });
