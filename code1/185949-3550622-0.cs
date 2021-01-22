    class TnsRegex
    {
        public void Test()
        {
            Regex reTns = new Regex(_pattern, RegexOptions.Singleline | RegexOptions.IgnorePatternWhitespace);
            MatchCollection matchCollection = reTns.Matches(_text);
            foreach (Match match in matchCollection)
            {
                foreach (Capture capture in match.Groups["Settings"].Captures)
                {
                    string[] setting = capture.Value.Split(new[] { '=' }, StringSplitOptions.RemoveEmptyEntries);
                    string key = setting[0].Trim();
                    string val = setting[1].Trim();
                    if (val.Contains("(")) continue;
                    switch (key)
                    {
                        case "HOST":
                            break;
                        case "PORT":
                            break;
                        case "SERVICE_NAME":
                            break;
                        case "SERVER":
                            break;
                    }
                    Console.WriteLine(key + ":" + val);
                }
            }
        }
        string _pattern = @"
            MYSCHEMA\s+=\s+\(
            [^\(\)]*
            (
                        (
                                    (?<Open>\()
                                    [^\(\)]*
                        )+
                        (
                                    (?<Settings-Open>\))
                                    [^\(\)]*
                        )+
            )*
            (?(Open)(?!))
        \)";
        string _text = @"
        MYSCHEMA =
          (DESCRIPTION =
            (ADDRESS = (PROTOCOL = TCP)(HOST = MYHOST)(PORT = 1234))
            (CONNECT_DATA =
              (SERVER = DEDICATED)
              (SERVICE_NAME = MYSERVICE.LOCAL )
            )
          )
        SOMESCHEMA =
          (DESCRIPTION =
            (ADDRESS_LIST =
              (ADDRESS = (PROTOCOL = TCP)(HOST = REMOTEHOST)(PORT = 1234))
            )
            (CONNECT_DATA = (SERVICE_NAME = REMOTE)
            )
          )
        ";
    }
