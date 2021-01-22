    static void CopyHeaders (HttpRequest sourceRequest, HttpWebRequest targetRequest) {
        foreach (string key in sourceRequest.Headers) {
            var value = sourceRequest.Headers[key];
            object objectValue = value;
            var propName = key.Replace("-", string.Empty);
            switch (key) {
                case "Host":
                case "Content-Length":
                    // Do not propogate Host and Content-Length.
                    continue;
                case "Connection":
                    // Cannot set the following values ...
                    if (value == "Keep-Alive" || value == "Close") {
                        continue;
                    }
                    break;
                case "If-Modified-Since":
                    objectValue = DateTime.Parse(value);
                    break;
            }
            var prop = targetRequest.GetType().GetProperty(propName, BindingFlags.Public | BindingFlags.Instance);
            if (null != prop && prop.CanWrite) {
                prop.SetValue(targetRequest, objectValue, null);
            } else {
                targetRequest.Headers[key] = Convert.ToString(value);
            }
        }
    }
