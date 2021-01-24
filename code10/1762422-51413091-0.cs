            Vars.hostnameInput = 
    @"AAABBBCCC-1234
    AAABBBCBC-1334
    AAABBCCBC-1324
    QEUVWISKPWW1114
    QEUSPISGPWW2114
    QEUSPISTPWW1614";
            var hostnameList = Vars.hostnameInput.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            var groups = from item in hostnameList
                group item by item.Substring(0, 3)
                into g
                select g;
            foreach (var _group in groups)
            {
                var wildcard = "";
                var hostnames = _group.OrderByDescending(t => t.Length).ToList();
                bool charMatch = false;
                var hostnameChars = hostnames[0].ToCharArray();
                for (var i = 0; i < hostnameChars.Length; i++)
                {
                    foreach (var hostname in hostnames)
                    {
                        try
                        {
                            if (hostnameChars[i] == hostname[i])
                            {
                                charMatch = true;
                            }
                            else
                            {
                                charMatch = false;
                                break;
                            }
                        }
                        catch (IndexOutOfRangeException)
                        {
                            charMatch = false;
                            break;
                        }
                    }
                    if (charMatch)
                    {
                        wildcard += hostnameChars[i];
                    }
                    else
                    {
                        wildcard += "?";
                    }
                }
                Vars.solrScript += $"{wildcard}\r\n";
                foreach (var hostname in _group)
                {
                    Vars.solrScript += $@"  {hostname}{Environment.NewLine}";
                }
                
            }
