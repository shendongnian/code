    public static class HttpUtils {
        public static string UserIp(this HttpRequestBase request)
        {
            var ip = request["HTTP_X_FORWARDED_FOR"];
            if (!string.IsNullOrWhiteSpace(ip))
            {
                ip = ip.Split(',').Last().Trim();
            }
            if (string.IsNullOrWhiteSpace(ip))
            {
                ip = request.UserHostAddress;
            }
            return ip;
        }
    }
