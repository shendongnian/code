        /// <summary>
        /// The arguments must be like: varName1, varValue1, varName2, varValue2 and so on.
        /// Empty names will be not be added to the result.
        /// Returns a string of the form varName1=varValue1&varName2=varValue2...
        /// </summary>    
        public static string BuildQueryString(params string[] strings)
        {
            Debug.Assert(0 == strings.GetLength(0) % 2);
            StringBuilder builder = new StringBuilder(50);
            bool isName = true;
            bool isEmptyName = false;
            foreach (string crtString in strings)
            {
                isEmptyName = (isName && string.IsNullOrEmpty(crtString)) ||
                    (!isName && isEmptyName);
                if (!isEmptyName)
                {
                    builder.Append(HttpUtility.UrlEncode(crtString));
                    if (isName)
                        builder.Append("=");
                    else
                        builder.Append("&");
                }
                isName = !isName;
            }
            return builder.ToString();
        }
