    public static string RemoveTags(string html)
        {
            string returnStr = "";
            bool insideTag = false;
            for (int i = 0; i < html.Length; ++i)
            {
                char c = html[i];
                if (c == '<')    
                    insideTag = true;
                if (!insideTag)
                    returnStr += c;
                if (c == '>')         
                    insideTag = false;
            }
            return returnStr;        
        }
