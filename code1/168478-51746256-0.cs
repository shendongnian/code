    public static string TruncateFunction(string value)
        {
            if (string.IsNullOrEmpty(value)) return "";
            else
            {
                string[] split = value.Split('.');
                if (split.Length > 0)
                {
                    string predecimal = split[0];
                    string postdecimal = split[1];
                    postdecimal = postdecimal.Length > 6 ? postdecimal.Substring(0, 6) : postdecimal;
                    return predecimal + "." + postdecimal;
                }
                else return value;
            }
        }
