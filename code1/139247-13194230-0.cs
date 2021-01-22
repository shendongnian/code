     private static bool TrySetSuppressScriptErrors(WebBrowser webBrowser, bool value)
        {
            FieldInfo field = typeof(WebBrowser).GetField("_axIWebBrowser2", BindingFlags.Instance | BindingFlags.NonPublic);
            if (field != null)
            {
                object axIWebBrowser2 = field.GetValue(webBrowser);
                if (axIWebBrowser2 != null)
                {
                    axIWebBrowser2.GetType().InvokeMember("Silent", BindingFlags.SetProperty, null, axIWebBrowser2, new object[] { value });
                    return true;
                }
            }
            return false;
        }
