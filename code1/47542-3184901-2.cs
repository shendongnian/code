    protected void Page_Load(object sender, EventArgs e)
    {
        string page = "";
        int counter = 0;
        foreach (string s in Request.QueryString.AllKeys)
        {
            if (s != Request.QueryString.Keys[0])
            {
                page += s;
                page += "=" + BinaryCodec.encode(Request.QueryString[counter]);
            }
            else
            {
                page += Request.QueryString[0];
            }
            if (!page.Contains('?'))
            {
                page += "?";
            }
            else
            {
                page += "&";
            }
            counter++;
        }
        page = page.TrimEnd('?');
        page = page.TrimEnd('&');
        Response.Redirect(page);
    }
    public class BinaryCodec
    {
        public static string encode(string ascii)
        {
            if (ascii == null)
            {
                return null;
            }
            else
            {
                char[] arrChars = ascii.ToCharArray();
                string binary = "";
                string divider = ".";
                foreach (char ch in arrChars)
                {
                    binary += Convert.ToString(Convert.ToInt32(ch), 2) + divider;
                }
                return binary;
            }
        }
    
        public static string decode(string binary)
        {
            if (binary == null)
            {
                return null;
            }
            else
            {
                try
                {
                    string[] arrStrings = binary.Trim('.').Split('.');
                    string ascii = "";
                    foreach (string s in arrStrings)
                    {
                        ascii += Convert.ToChar(Convert.ToInt32(s, 2));
                    }
                    return ascii;
                }
                catch (FormatException)
                {
                    throw new FormatException("SECURITY ALERT! You cannot access a page by entering its URL.");
                }
            }
        }
    }
