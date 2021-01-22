            /// <summary>
            /// Gets the login URL for the given portal from the current <paramref name="request"/>.
            /// </summary>
            /// <param name="portalSettings">The portal settings.</param>
            /// <param name="request">The request.</param>
            /// <returns>The URL for the login page</returns>
            /// <exception cref="ArgumentNullException">if <paramref name="portalSettings"/> or <paramref name="request"/> is null.</exception>
            public static string GetLoginUrl(PortalSettings portalSettings, HttpRequest request)
            {
                if (portalSettings != null && request != null)
                {
                    int tabId = portalSettings.ActiveTab.TabID;
                    string controlKey = "Login";
                    string returnUrl = request.RawUrl;
                    if (returnUrl.IndexOf("?returnurl=", StringComparison.OrdinalIgnoreCase) > -1)
                    {
                        returnUrl = returnUrl.Substring(0, returnUrl.IndexOf("?returnurl=", StringComparison.OrdinalIgnoreCase));
                    }
    
                    returnUrl = HttpUtility.UrlEncode(returnUrl);
    
                    if (!Null.IsNull(portalSettings.LoginTabId) && string.IsNullOrEmpty(request.QueryString["override"]))
                    {
                        // user defined tab
                        controlKey = string.Empty;
                        tabId = portalSettings.LoginTabId;
                    }
                    else if (!Null.IsNull(portalSettings.HomeTabId))
                    {
                        // portal tab
                        tabId = portalSettings.HomeTabId;
                    }
    
                    // else current tab
                    return Globals.NavigateURL(tabId, controlKey, new string[] { "returnUrl=" + returnUrl });
                }
                
                throw new ArgumentNullException(portalSettings == null ? "portalSettings" : "request");
            }
