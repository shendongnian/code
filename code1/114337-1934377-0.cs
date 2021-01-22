      Regex rgx = new Regex("<Icon>.*</Icon>");
       MatchCollection matches = rgx.Matches(xml);
       
       foreach (Match match in matches)
        {
    	string s= match.Value;
    	s= s.Remove(0,6)
    	s= s.Remove(s.LastIndexOf("</Icon>"),7);
    	console.Writeline(s);
        }
   
