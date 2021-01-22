        [DebuggerDisplay("Name {Name} Host:{Host} ServiceName:{ServiceName} Port:{Port}")]
        public class TnsEntry
        {
            public string Name { get; set; }
            public string Host { get; set; }
            public string Port { get; set; }
            public string ServiceName { get; set; }
        }
       public class TnsNamesFileParser
       {
        public string TNSNamesContents { get; set; }
        public TnsNamesFileParser()
        {
        }
        public TnsNamesFileParser(string locationAndNameOfTnsNamesFile)
        {
            TNSNamesContents = System.IO.File.ReadAllText(locationAndNameOfTnsNamesFile);
        }
        public List<TnsEntry> Parse()
        {
            return Parse(TNSNamesContents);
        }
        public List<TnsEntry> Parse(string TNSNamesContents)
        {
            string TNSPattern = @"([\w -] +)\s *= (?:\s |.) +?\)\s *\)\s *\)\s * ((?=[\w\-])|(?=$))";
            Regex reTns = new Regex(TNSPattern, RegexOptions.Singleline | RegexOptions.IgnorePatternWhitespace);
            MatchCollection matchCollection = reTns.Matches(TNSNamesContents);
            var TnsEntries = new List<TnsEntry>();
            foreach (Match match in matchCollection)
            {
                var tnsEntry = new TnsEntry();
                string matchedValue = match.Value.Trim();
                tnsEntry.Name = Regex.Match(matchedValue, @"^([^\s]+)", RegexOptions.IgnoreCase)?.Value.Trim();
                tnsEntry.Host = Regex.Match(matchedValue, "(?<=HOST.+=) ([^)]*)", RegexOptions.IgnoreCase)?.Value.Trim();
                tnsEntry.Port = Regex.Match(matchedValue, "(?<=PORT.+=) ([^)]*)", RegexOptions.IgnoreCase)?.Value.Trim();
                tnsEntry.ServiceName = Regex.Match(matchedValue, "(?<=SERVICE_NAME.+=) ([^)]*)", RegexOptions.IgnoreCase)?.Value;
                TnsEntries.Add(tnsEntry);
            }
            return TnsEntries;
        }
      }
    //Test Code: 
    string testdata =@"
            SOMESCHEMA =
            (DESCRIPTION =
            (ADDRESS_LIST =
            (ADDRESS = (PROTOCOL = TCP)(HOST = REMOTEHOST)(PORT = 1234))
            )
            (CONNECT_DATA = (SERVICE_NAME = REMOTE)
            )
            )
    
            MYSCHEMA =
            (DESCRIPTION =
            (ADDRESS = (PROTOCOL = TCP)(HOST = MYHOST)(PORT = 1234))
            (CONNECT_DATA =
            (SERVER = DEDICATED)
            (SERVICE_NAME = MYSERVICE.LOCAL )
            )
            )
    
            MYOTHERSCHEMA =
            (DESCRIPTION =
            (ADDRESS_LIST =
            (ADDRESS = (PROTOCOL = TCP)(HOST = MYHOST)(PORT = 1234))
            )
            (CONNECT_DATA = 
            (SERVICE_NAME = MYSERVICE.REMOTE)
            )
            )
    
            SOMEOTHERSCHEMA = 
            (DESCRIPTION =
            (ADDRESS_LIST =
            (ADDRESS = (PROTOCOL = TCP)(HOST = LOCALHOST)(PORT = 1234))
            )
            (CONNECT_DATA =
            (SERVICE_NAME = LOCAL)
            )
            )";
     [Test]
     public void ParseTNSFileEntries()
     {
                
      var tnsNamesFileParser = new TnsNamesFileParser();
      var entries =  tnsNamesFileParser.Parse(testdata);
    
    
     }
