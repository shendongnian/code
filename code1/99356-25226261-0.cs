    public string Truncate(string content, int length)
        {
            try
            {
                return content.Substring(0,content.IndexOf(" ",length)) + "...";
            }
            catch
            {
                return content;
            }
        }
