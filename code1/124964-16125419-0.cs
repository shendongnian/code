        public static string ToUrlFriendlyString(this string value)
        {
            value = (value ?? "").Trim().ToLower();
            var url = new StringBuilder();
            foreach (char ch in value)
            {
                switch (ch)
                {
                    case ' ':
                        url.Append('-');
                        break;
                    default:
                        url.Append(Regex.Replace(ch.ToString(), @"[^A-Za-z0-9'()\*\\+_~\:\/\?\-\.,;=#\[\]@!$&]", ""));
                        break;
                }
            }
            return url.ToString();
        }
