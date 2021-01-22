                Func<Match, String> NamespaceRemover = delegate (Match match)
                {
                    var result = match.Value;
                    if (String.IsNullOrEmpty(match.Groups["cdata"].Value))
                    {
                        // find all prefixes within start-, end tag and attributes and also namespace declarations
                        return Regex.Replace(result, "((?<=<|<\\/| ))\\w+:| xmlns(:\\w+)?=\".*?\"", "");
                    }
                    else
                    {
                        // cdata as is
                        return result;
                    }
                };
                // XmlDocument doc;
                // string file;
                doc.LoadXml(
                  Regex.Replace(File.ReadAllText(file), 
                    // find all begin, cdata and end tags (do not change order)
                    @"<(?:\w+:?\w+.*?|(?<cdata>!\[CDATA\[.*?\]\])|\/\w+:?\w+)>", 
                    new MatchEvaluator(NamespaceRemover)
                  )
                );
    
