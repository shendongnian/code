    private void ParseObject(StringBuilder body, string parser)  
    {
        List<string> pages = new List<string>();
    
        string data = body.ToString();
        int splitPos = 0;
        int startPos = 0;
        while(true)
        {
            int totalPos = data.IndexOf("Other Total:", splitPos);
            if(totalPos != -1)
            {
               splitPos = data.IndexOf(Helper.NewLine, totalPos);
               pages.Add(data.Substring(startPos, totalPos);
               splitPos = totalPos;
               startPos = totalPos;
            }
            else
               break;
        }
    }
