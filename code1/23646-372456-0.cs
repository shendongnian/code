        private static readonly Regex ShortDate = new Regex(@"^\d{6}$");
        private static readonly Regex LongDate = new Regex(@"^\d{8}$");
        public object Parse(object value, out string message)
        {
            msg = null;
            string s = value.ToString().Trim();
            if (s.Trim() == "")
            {
                return null;
            }
            else
            {
                if (ShortDate.Match(s).Success)
                {
                    s = s.Substring(0, 2) + "/" + s.Substring(2, 2) + "/" + s.Substring(4, 2);
                }
                if (LongDate.Match(s).Success)
                {
                    s = s.Substring(0, 2) + "/" + s.Substring(2, 2) + "/" + s.Substring(4, 4);
                }
                DateTime d = DateTime.MinValue;
                if (DateTime.TryParse(s, out d))
                {
                    return d;
                }
                else
                {
                    message = String.Format("\"{0}\" is not a valid date.", s);
                    return null;
                }
            }
        }
