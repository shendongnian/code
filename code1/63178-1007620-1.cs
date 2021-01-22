            string html;
              
            // Populate the html string here
            RegexOptions options = RegexOptions.IgnoreCase | RegexOptions.Singleline;
            Regex regx = new Regex( "<body>(?<theBody>.*)</body>", options );
            Match match = regx.Match( html );
            if ( match.Success ) {
                string theBody = match.Groups["theBody"].Value;
            }
