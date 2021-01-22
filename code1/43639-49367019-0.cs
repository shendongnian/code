    public static class StringFormatToWhatever
    {
        public static string ToPhoneFormat(this string text)
        {        
            string rt = "";
            if (text.Length > 0)
            {            
                rt += '(';
                int n = 1;
                foreach (char c in text)
                {
                    rt += c;
                    if (n == 3) { rt += ") "; }
                    else if (n == 6) { rt += "-"; }
                    n++;
                }
            }
            return rt;
        }
    }
