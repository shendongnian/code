    string numberOfFriends;
    
    HtmlElementCollection elems = webBrowser1.Document.GetElementsByTagName( "div" );
    foreach( HtmlElement elem in elems )
    {
      string class = elem.GetAttribute( "class" );
      if( !string.IsNullOrEmpty( class ) && "alertText".Equals( class ) )
      {
        string content = elem.InnerText;
        if( Regex.IsMatch( content, "\\d+ friends joined" ) )
        {
          numberOfFriends = Regex.Match( content, "(\\d+) friends joined" ).Groups[ 1 ].Value;
        }
      }
    }
