                Regex r = new Regex(negRegexPattern, RegexOptions.IgnoreCase | RegexOptions.Singleline);
                MatchCollection mc = r.Matches(text);
                
                    int counter = 0;
                    for (int i = 0; i < mc.Count; i++)
                    {
                        text = text.Remove(mc[i].Index + counter, mc[i].Length);
                        text = text.Insert(mc[i].Index + counter, "<td>" + mc[i].Value + "</td>");
                        counter += ("<td>" +  "</td>").Length;
                    }
                
            
