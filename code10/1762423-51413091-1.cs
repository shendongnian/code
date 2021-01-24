            //Variables class I created elsewhere
			Vars.hostnameInput = 
    @"AAABBBCCC-1234
    AAABBBCBC-1334
    AAABBCCBC-1324
    QEUVWISKPWW1114
    QEUSPISGPWW2114
    QEUSPISTPWW1614";
			
			//Split the string into a list
            var hostnameList = Vars.hostnameInput.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
			//Create groups where the first three characters match
            var groups = from item in hostnameList
                group item by item.Substring(0, 3)
                into g
                select g;
			
			//Iterate through each group
            foreach (var _group in groups)
            {
                var wildcard = "";
				//Order the list so that the longest string in the group is at the top
                var hostnames = _group.OrderByDescending(t => t.Length).ToList();
                bool charMatch = false;
				//Split longest string in the group into a Char array to compare to the rest in the group
                var hostnameChars = hostnames[0].ToCharArray();
                for (var i = 0; i < hostnameChars.Length; i++)
                {
                    foreach (var hostname in hostnames)
                    {
                        try
                        {
							//Check the character in each string at the same index
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
						//If the current string is shorter, the extra characters should result in a '?'
                        catch (IndexOutOfRangeException)
                        {
                            charMatch = false;
                            break;
                        }
                    }
					//If all characters at index i match, leave it in, if not, replace with '?'
                    if (charMatch)
                    {
                        wildcard += hostnameChars[i];
                    }
                    else
                    {
                        wildcard += "?";
                    }
                }
				//Add new wildcard terms to output
                Vars.solrScript += $"{wildcard}\r\n";
                foreach (var hostname in _group)
                {
                    Vars.solrScript += $@"  {hostname}{Environment.NewLine}";
                }
                
            }
