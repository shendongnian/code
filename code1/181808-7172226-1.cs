            HttpRequest equest =  this.Request;
            NameValueCollection headers = Request.Headers;
            //get a type
            Type t = headers.GetType();         
            t.InvokeMember("MakeReadWrite", BindingFlags.InvokeMethod | 
                  BindingFlags.NonPublic | BindingFlags.Instance, null, headers, null);
            t.InvokeMember("InvalidateCachedArrays", BindingFlags.InvokeMethod |
                  BindingFlags.NonPublic | BindingFlags.Instance, null, headers, null);
            System.Collections.ArrayList item = new System.Collections.ArrayList();
            item.Add("YOUR_STYLE_NAME");
            t.InvokeMember("BaseAdd", BindingFlags.InvokeMethod | BindingFlags.NonPublic |
                  BindingFlags.Instance, null, headers, new object[] { "CUSTOM_STYLE", item });
            t.InvokeMember("MakeReadOnly", BindingFlags.InvokeMethod |
                  BindingFlags.NonPublic | BindingFlags.Instance, null, headers, null);
            Server.Transfer("Default.aspx");
