    while ((line = sr.ReadLine()) != null)
                {
    
                    string[] finds = findText.Split(',');
    
                    bool found = false;
                    foreach (string find in finds)
                    {
                        if (Regex.IsMatch(line, find, RegexOptions.IgnoreCase))
                        {
                            found = true;
                            Regex regexText = new Regex(find, RegexOptions.IgnoreCase);
                            line = regexText.Replace(line, "<span style =\"background-color: #FFFF00\">" + find + " </span>");
                            builder.Append(line);
                        }
                    }
                    if (!found)
                    {
                        builder.Append(line);
                        builder.Append("<br/>");
                    }
                }
