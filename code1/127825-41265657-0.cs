    public string DecodeQP(string cadena)
    {
        Regex codificadas;
        cadena = cadena.Trim();
        
        codificadas=new Regex(@"=\?((?!\?=).)*\?=", RegexOptions.IgnoreCase);
        MatchCollection setMatches = codificadas.Matches(cadena);
        if(setMatches.Count > 0)
        {
            Attachment attdecode;
            cadena = "";
            foreach (Match match in setMatches)
            {
                attdecode = Attachment.CreateAttachmentFromString("", match.Value);
                cadena += attdecode.Name;
                 
            }                
        }
        return cadena;
    }
