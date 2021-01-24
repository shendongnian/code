            string str ="Ł9CZIA KUOTA PIV 1,21 SUMA 12,36 otóuka 2 | 0350 |tKasa 1";
            var sentences = new List<String>();
            int position = 0, start = 0;
            
            do{
                position = str.IndexOf("SUMA", start);
                if (position >= 0){
                    str = str.Substring(position).Trim();
                    start += 5;
                    position = str.IndexOf("SUMA", start);
                    if (position >= 0){
                        string _str = str.Substring(0,position).Trim();
                        sentences.Add(_str);
                        str = str.Substring(position).Trim();
                        start = 0;
                    }
                    else
                        sentences.Add(str);
                    
                    
                }
            } while (position > 0);
            // Extract decimal 
            string pattern = @"(\d+,\d+)";
            Regex r = new Regex(pattern);
            
            foreach (var sentence in sentences){
                    Match match = r.Match(sentence);
                    Console.WriteLine(match.Groups[1]); 
            }
