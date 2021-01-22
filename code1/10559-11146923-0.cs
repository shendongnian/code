    static void CopyRequestHeaders (HttpRequest sourceRequest, HttpWebRequest targetRequest) {
        foreach (string key in sourceRequest.Headers) {
            var value = sourceRequest.Headers[key];
            var propName = key.Replace("-", string.Empty);
            switch (key) {
                case "Host":
                case "Content-Length":
                    // Do not propagate Host and Content-Length directly, as HttpWebRequest deals with this...
                    continue;
                case "Connection":
                    // Cannot set the following values at all ...
                    if (value == "Keep-Alive" || value == "Close") {
                        continue;
                    }
                    break;
            }
            var prop = targetRequest.GetType().GetProperty(propName, BindingFlags.Public | BindingFlags.Instance);
            if (null != prop && prop.CanWrite) {
                prop.SetValue(targetRequest, value, null);
            } else {
                targetRequest.Headers[key] = value;
            }
        }
    }
