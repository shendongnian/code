        public static void Navigate(string url, Action<Exception, UIElement> callback)
        {
            Navigate(new Uri(url, UriKind.RelativeOrAbsolute), callback);
        }
        public static void Navigate(Uri uri, Action<Exception, UIElement> callback)
        {
            if (rootFrame == null)
            {
                Logger.LogMessage("Can't use navigation, because rootFrame is null");
                ErrorMessageBox.Show(ClientStrings.NavigationFailed);
            }
            else
            {
                NavigatedEventHandler successHandler = null;
                NavigationFailedEventHandler failureHandler = null;
                successHandler = (s, e) =>
                     {
                         rootFrame.Navigated -= successHandler;
                         rootFrame.NavigationFailed -= failureHandler;
                         if (callback != null)
                         {
                             callback(null, e.Content as UIElement);
                         }
                     };
                failureHandler = (s, e) =>
                    {
                        rootFrame.Navigated -= successHandler;
                        rootFrame.NavigationFailed -= failureHandler;
                        if (callback != null)
                        {
                            callback(e.Exception, null);
                        }
                    };
                rootFrame.Navigated += successHandler;
                rootFrame.NavigationFailed += failureHandler;
                rootFrame.Navigate(uri);
            }
        }
