    public string DecodeQP(string codedstring)
    {
        Regex codified;
        
        codified=new Regex(@"=\?((?!\?=).)*\?=", RegexOptions.IgnoreCase);
        MatchCollection setMatches = codified.Matches(cadena);
        if(setMatches.Count > 0)
        {
            Attachment attdecode;
            codedstring= "";
            foreach (Match match in setMatches)
            {
                attdecode = Attachment.CreateAttachmentFromString("", match.Value);
                codedstring+= attdecode.Name;
                 
            }                
        }
        return codedstring;
    }
